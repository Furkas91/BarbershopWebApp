using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BarbershopWebApp.Domain;
using BarbershopWebApp.Domain.Contracts;
using BarbershopWebApp.Domain.Models;

namespace BarbershopWebApp.BLL.Contracts
{
    public interface IConsumerService
    {
        Task<IEnumerable<Consumer>> GetAsync();
        Task<Consumer> GetAsync(IConsumerIdentity id);
        Task<Consumer> CreateAsync(ConsumerUpdateModel consumer);
        Task<Consumer> UpdateAsync(ConsumerUpdateModel consumer);
        Task ValidateAsync(IConsumerContainer consumerContainer);
    }
}