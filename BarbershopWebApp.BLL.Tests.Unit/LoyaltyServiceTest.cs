using System;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Moq;
using BarbershopWebApp.BLL.Contracts;
using BarbershopWebApp.BLL.Implementation;
using BarbershopWebApp.DAL.Contracts;
using BarbershopWebApp.Domain;
using BarbershopWebApp.Domain.Contracts;
using BarbershopWebApp.Domain.Models;
using NUnit.Framework;

namespace BarbershopWebApp.BLL.Tests.Unit
{
    [TestFixture]
    public class LoyaltyServiceTest
    {
        [Test]
        public async Task ValidateAsync_loyaltyExists_DoesNothing()
        {
            // Arrange
            var loyaltyContainer = new Mock<ILoyaltyContainer>();

            var loyalty = new Loyalty();
            var loyaltyDAL = new Mock<ILoyaltyDAL>();
            var loyaltyIdentity = new Mock<ILoyaltyIdentity>();
            loyaltyDAL.Setup(x => x.GetAsync(loyaltyIdentity.Object)).ReturnsAsync(loyalty);

            var loyaltyGetService = new LoyaltyService(loyaltyDAL.Object);
            
            // Act
            var action = new Func<Task>(() => loyaltyGetService.ValidateAsync(loyaltyContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_loyaltyNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            var loyaltyContainer = new Mock<ILoyaltyContainer>();
            loyaltyContainer.Setup(x => x.LoyaltyId).Returns(id);
            var loyaltyIdentity = new Mock<ILoyaltyIdentity>();
            var loyalty = new Loyalty();
            var loyaltyDAL = new Mock<ILoyaltyDAL>();
            loyaltyDAL.Setup(x => x.GetAsync(loyaltyIdentity.Object)).ReturnsAsync((Loyalty) null);

            var loyaltyGetService = new LoyaltyService(loyaltyDAL.Object);

            // Act
            var action = new Func<Task>(() => loyaltyGetService.ValidateAsync(loyaltyContainer.Object));
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Loyalty not found by id {id}");
        }
        
        [Test]
        public async Task CreateAsync_loyaltyValidationSucceed_Createsloyalty()
        {
            // Arrange
            var loyalty = new LoyaltyUpdateModel();
            var expected = new Loyalty();
            
            var loyaltyDAL = new Mock<ILoyaltyDAL>();
            loyaltyDAL.Setup(x => x.InsertAsync(loyalty)).ReturnsAsync(expected);

            var loyaltyService = new LoyaltyService(loyaltyDAL.Object);
            
            // Act
            var result = await loyaltyService.CreateAsync(loyalty);
            
            // Assert
            result.Should().Be(expected);
        }
    }
}