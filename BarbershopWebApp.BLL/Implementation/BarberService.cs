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
    public class BarberService:IBarberService
    {
        private IBarberDAL BarberDAL { get; }
        
        public BarberService(IBarberDAL barberDAL)
        {
            this.BarberDAL = barberDAL;
        }
        
        public async Task<Barber> CreateAsync(BarberUpdateModel barber) {
            return await this.BarberDAL.InsertAsync(barber);
        }
        
        public async Task<Barber> UpdateAsync(BarberUpdateModel barber) {
            return await this.BarberDAL.UpdateAsync(barber);
        }
        
        public Task<IEnumerable<Barber>> GetAsync() {
            return this.BarberDAL.GetAsync();
        }
        
        public Task<Barber> GetAsync(IBarberIdentity id)
        {
            return this.BarberDAL.GetAsync(id);
        }
        
        public async Task ValidateAsync(IBarberContainer barberContainer)
        {
            if (barberContainer == null)
            {
                throw new ArgumentNullException(nameof(barberContainer));
            }
     
            if (barberContainer.BarberId.HasValue)
            {
                var department = await this.BarberDAL.GetAsync(new BarberIdentityModel((int) barberContainer.BarberId));
                if(department == null) 
                    throw new InvalidOperationException($"Barber not found by id {barberContainer.BarberId}");
            }
        }
    }
}