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
    public class ConsumerServiceTest
    {
        [Test]
        public async Task ValidateAsync_consumerExists_DoesNothing()
        {
            // Arrange
            var consumerContainer = new Mock<IConsumerContainer>();

            var consumer = new Consumer();
            var loyaltyService = new Mock<ILoyaltyService>();
            var consumerDAL = new Mock<IConsumerDAL>();
            var consumerIdentity = new Mock<IConsumerIdentity>();
            consumerDAL.Setup(x => x.GetAsync(consumerIdentity.Object)).ReturnsAsync(consumer);

            var consumerGetService = new ConsumerService(consumerDAL.Object,loyaltyService.Object);
            
            // Act
            var action = new Func<Task>(() => consumerGetService.ValidateAsync(consumerContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_consumerNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            var consumerContainer = new Mock<IConsumerContainer>();
            consumerContainer.Setup(x => x.ConsumerId).Returns(id);
            var consumerIdentity = new Mock<IConsumerIdentity>();
            var loyaltyService = new Mock<ILoyaltyService>();
            var consumer = new Consumer();
            var consumerDAL = new Mock<IConsumerDAL>();
            consumerDAL.Setup(x => x.GetAsync(consumerIdentity.Object)).ReturnsAsync((Consumer) null);

            var consumerGetService = new ConsumerService(consumerDAL.Object,loyaltyService.Object);

            // Act
            var action = new Func<Task>(() => consumerGetService.ValidateAsync(consumerContainer.Object));
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Consumer not found by id {id}");
        }
        
        [Test]
        public async Task CreateAsync_consumerValidationSucceed_Createsconsumer()
        {
            // Arrange
            var consumer = new ConsumerUpdateModel();
            var expected = new Consumer();
            
            var loyaltyService = new Mock<ILoyaltyService>();
            loyaltyService.Setup(x => x.ValidateAsync(consumer));

            var consumerDAL = new Mock<IConsumerDAL>();
            consumerDAL.Setup(x => x.InsertAsync(consumer)).ReturnsAsync(expected);

            var consumerService = new ConsumerService(consumerDAL.Object, loyaltyService.Object);
            
            // Act
            var result = await consumerService.CreateAsync(consumer);
            
            // Assert
            result.Should().Be(expected);
        }
        
        [Test]
        public async Task CreateAsync_consumerValidationFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var consumer = new ConsumerUpdateModel();
            var expected = fixture.Create<string>();
            
            var loyaltyService = new Mock<ILoyaltyService>();
            loyaltyService
                .Setup(x => x.ValidateAsync(consumer))
                .Throws(new InvalidOperationException(expected));
            
            var consumerDAL = new Mock<IConsumerDAL>();
            
            var consumerService = new ConsumerService(consumerDAL.Object, loyaltyService.Object);
            
            var action = new Func<Task>(() => consumerService.CreateAsync(consumer));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            consumerDAL.Verify(x => x.InsertAsync(consumer), Times.Never);
        }
    }
}