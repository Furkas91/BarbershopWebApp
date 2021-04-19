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
    public class HaircutServiceTest
    {
        [Test]
        public async Task ValidateAsync_haircutExists_DoesNothing()
        {
            // Arrange
            var haircutContainer = new Mock<IHaircutContainer>();

            var haircut = new Haircut();
            var haircutDAL = new Mock<IHaircutDAL>();
            var haircutIdentity = new Mock<IHaircutIdentity>();
            haircutDAL.Setup(x => x.GetAsync(haircutIdentity.Object)).ReturnsAsync(haircut);

            var haircutGetService = new HaircutService(haircutDAL.Object);
            
            // Act
            var action = new Func<Task>(() => haircutGetService.ValidateAsync(haircutContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_haircutNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            var haircutContainer = new Mock<IHaircutContainer>();
            haircutContainer.Setup(x => x.HaircutId).Returns(id);
            var haircutIdentity = new Mock<IHaircutIdentity>();
            var haircut = new Haircut();
            var haircutDAL = new Mock<IHaircutDAL>();
            haircutDAL.Setup(x => x.GetAsync(haircutIdentity.Object)).ReturnsAsync((Haircut) null);

            var haircutGetService = new HaircutService(haircutDAL.Object);

            // Act
            var action = new Func<Task>(() => haircutGetService.ValidateAsync(haircutContainer.Object));
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Haircut not found by id {id}");
        }
        
        [Test]
        public async Task CreateAsync_haircutValidationSucceed_Createsloyalty()
        {
            // Arrange
            var haircut = new HaircutUpdateModel();
            var expected = new Haircut();
            
            var haircutDAL = new Mock<IHaircutDAL>();
            haircutDAL.Setup(x => x.InsertAsync(haircut)).ReturnsAsync(expected);

            var haircutService = new HaircutService(haircutDAL.Object);
            
            // Act
            var result = await haircutService.CreateAsync(haircut);
            
            // Assert
            result.Should().Be(expected);
        }
    }
}