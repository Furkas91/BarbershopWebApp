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
    public class LoyaltyService:ILoyaltyService
    {
        private ILoyaltyDAL LoyaltyDAL { get; }
        
        public LoyaltyService(ILoyaltyDAL loyaltyDAL)
        {
            this.LoyaltyDAL = loyaltyDAL;
        }
        
        public async Task<Loyalty> CreateAsync(LoyaltyUpdateModel loyalty) {
            return await this.LoyaltyDAL.InsertAsync(loyalty);
        }
        
        public async Task<Loyalty> UpdateAsync(LoyaltyUpdateModel loyalty) {
            return await this.LoyaltyDAL.UpdateAsync(loyalty);
        }
        
        public Task<IEnumerable<Loyalty>> GetAsync() {
            return this.LoyaltyDAL.GetAsync();
        }
        
        public Task<Loyalty> GetAsync(ILoyaltyIdentity id)
        {
            return this.LoyaltyDAL.GetAsync(id);
        }
        public async Task ValidateAsync(ILoyaltyContainer loyaltyContainer){
            if (loyaltyContainer == null)
            {
                throw new ArgumentNullException(nameof(loyaltyContainer));
            }
            else
            {
                if (loyaltyContainer.LoyaltyId.HasValue)
                {
                    var department = await this.LoyaltyDAL.GetAsync(new LoyaltyIdentityModel(loyaltyContainer.LoyaltyId.Value));
                    if (department == null)
                        throw new InvalidOperationException($"Loyalty not found by id {loyaltyContainer.LoyaltyId}");
                }
            }
        }
    }
}