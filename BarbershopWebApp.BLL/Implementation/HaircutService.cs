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
    public class HaircutService:IHaircutService
    {
        private IHaircutDAL HaircutDAL { get; }
        
        public HaircutService(IHaircutDAL haircutDAL)
        {
            this.HaircutDAL = haircutDAL;
        }
        
        public async Task<Haircut> CreateAsync(HaircutUpdateModel haircut) {
            return await this.HaircutDAL.InsertAsync(haircut);
        }
        
        public async Task<Haircut> UpdateAsync(HaircutUpdateModel haircut) {
            return await this.HaircutDAL.UpdateAsync(haircut);
        }
        
        public Task<IEnumerable<Haircut>> GetAsync() {
            return this.HaircutDAL.GetAsync();
        }
        
        public Task<Haircut> GetAsync(IHaircutIdentity id)
        {
            return this.HaircutDAL.GetAsync(id);
        }
        
        public async Task ValidateAsync(IHaircutContainer haircutContainer)
        {
            if (haircutContainer == null)
            {
                throw new ArgumentNullException(nameof(haircutContainer));
            }
            if (haircutContainer.HaircutId.HasValue )
            {
                var department = await this.HaircutDAL.GetAsync(new HaircutIdentityModel(haircutContainer.HaircutId.Value));
                if(department == null)
                    throw new InvalidOperationException($"Department not found by id {haircutContainer.HaircutId}");
            }
        }
    }
}