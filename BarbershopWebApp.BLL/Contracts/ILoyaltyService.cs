using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BarbershopWebApp.Domain;
using BarbershopWebApp.Domain.Contracts;
using BarbershopWebApp.Domain.Models;

namespace BarbershopWebApp.BLL.Contracts
{
    public interface ILoyaltyService
    {
        Task<IEnumerable<Loyalty>> GetAsync();
        Task<Loyalty> GetAsync(ILoyaltyIdentity id);
        Task<Loyalty> CreateAsync(LoyaltyUpdateModel loyalty);
        Task<Loyalty> UpdateAsync(LoyaltyUpdateModel loyalty);
        Task ValidateAsync(ILoyaltyContainer loyaltyContainer);
    }
}