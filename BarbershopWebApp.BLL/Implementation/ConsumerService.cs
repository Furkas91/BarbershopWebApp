using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BarbershopWebApp.BLL.Contracts;
using BarbershopWebApp.DAL.Contracts;
using BarbershopWebApp.Domain;
using BarbershopWebApp.Domain.Contracts;
using BarbershopWebApp.Domain.Models;

namespace BarbershopWebApp.BLL.Implementation
{
    public class ConsumerService: IConsumerService
    {
        private IConsumerDAL ConsumerDAL { get; }
        private ILoyaltyService LoyaltyService { get; }
        
        public ConsumerService(IConsumerDAL consumerDAL, ILoyaltyService loyaltyService)
        {
            this.ConsumerDAL = consumerDAL;
            this.LoyaltyService = loyaltyService;
        }
        
        public async Task<Consumer> CreateAsync(ConsumerUpdateModel consumer) {
            await this.LoyaltyService.ValidateAsync(consumer);
            return await this.ConsumerDAL.InsertAsync(consumer);
        }
        
        public async Task<Consumer> UpdateAsync(ConsumerUpdateModel consumer) {
            await this.LoyaltyService.ValidateAsync(consumer);
            return await this.ConsumerDAL.UpdateAsync(consumer);
        }
        
        public Task<IEnumerable<Consumer>> GetAsync() {
            return this.ConsumerDAL.GetAsync();
        }
        
        public Task<Consumer> GetAsync(IConsumerIdentity id)
        {
            return this.ConsumerDAL.GetAsync(id);
        }
        
        public async Task ValidateAsync(IConsumerContainer consumerContainer)
        {
            if (consumerContainer == null)
            {
                throw new ArgumentNullException(nameof(consumerContainer));
            }
            if (consumerContainer.ConsumerId.HasValue)
            {
                var department = await this.ConsumerDAL.GetAsync(new ConsumerIdentityModel(consumerContainer.ConsumerId.Value));
                if( department == null)
                    throw new InvalidOperationException($"Department not found by id {consumerContainer.ConsumerId}");
            }
        }
    }
}