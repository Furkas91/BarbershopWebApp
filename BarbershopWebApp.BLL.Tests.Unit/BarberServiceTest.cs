using System;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Moq;
using BarbershopWebApp.BLL.Implementation;
using BarbershopWebApp.DAL.Contracts;
using BarbershopWebApp.Domain;
using BarbershopWebApp.Domain.Contracts;
using BarbershopWebApp.Domain.Models;
using NUnit.Framework;

namespace BarbershopWebApp.BLL.Tests.Unit
{
    [TestFixture]
    public class BarberServiceTest
    {
        [Test]
        public async Task ValidateAsync_barberExists_DoesNothing()
        {
            // Arrange
            var barberContainer = new Mock<IBarberContainer>();

            var barber = new Barber();
            var barberDAL = new Mock<IBarberDAL>();
            var barberIdentity = new Mock<IBarberIdentity>();
            barberDAL.Setup(x => x.GetAsync(barberIdentity.Object)).ReturnsAsync(barber);

            var barberGetService = new BarberService(barberDAL.Object);
            
            // Act
            var action = new Func<Task>(() => barberGetService.ValidateAsync(barberContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_barberNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            var barberContainer = new Mock<IBarberContainer>();
            barberContainer.Setup(x => x.BarberId).Returns(id);
            var barberIdentity = new Mock<IBarberIdentity>();
            var barber = new Barber();
            var barberDAL = new Mock<IBarberDAL>();
            barberDAL.Setup(x => x.GetAsync(barberIdentity.Object)).ReturnsAsync((Barber) null);

            var barberGetService = new BarberService(barberDAL.Object);

            // Act
            var action = new Func<Task>(() => barberGetService.ValidateAsync(barberContainer.Object));
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Barber not found by id {id}");
        }
        
        [Test]
        public async Task CreateAsync_barberValidationSucceed_Createsloyalty()
        {
            // Arrange
            var barber = new BarberUpdateModel();
            var expected = new Barber();

            var barberDAL = new Mock<IBarberDAL>();
            barberDAL.Setup(x => x.InsertAsync(barber)).ReturnsAsync(expected);

            var barberService = new BarberService(barberDAL.Object);
            
            // Act
            var result = await barberService.CreateAsync(barber);
            
            // Assert
            result.Should().Be(expected);
        }
    }
}