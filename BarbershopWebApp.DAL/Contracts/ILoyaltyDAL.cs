using System.Collections.Generic;
using System.Threading.Tasks;
using BarbershopWebApp.Domain;
using BarbershopWebApp.Domain.Contracts;
using BarbershopWebApp.Domain.Models;

namespace BarbershopWebApp.DAL.Contracts
{
    public interface ILoyaltyDAL
    {
        Task<Loyalty> InsertAsync(LoyaltyUpdateModel loyalty);
        Task<IEnumerable<Loyalty>> GetAsync();
        Task<Loyalty> GetAsync(ILoyaltyIdentity loyaltyId);
        Task<Loyalty> UpdateAsync(LoyaltyUpdateModel loyalty);
    }
}