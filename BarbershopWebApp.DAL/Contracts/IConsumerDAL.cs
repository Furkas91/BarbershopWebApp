using System.Collections.Generic;
using System.Threading.Tasks;
using BarbershopWebApp.Domain;
using BarbershopWebApp.Domain.Contracts;
using BarbershopWebApp.Domain.Models;

namespace BarbershopWebApp.DAL.Contracts
{
    public interface IConsumerDAL
    {
        Task<Consumer> InsertAsync(ConsumerUpdateModel consumer);
        Task<IEnumerable<Consumer>> GetAsync();
        Task<Consumer> GetAsync(IConsumerIdentity consumerId);
        Task<Consumer> UpdateAsync(ConsumerUpdateModel consumer);
    }
}