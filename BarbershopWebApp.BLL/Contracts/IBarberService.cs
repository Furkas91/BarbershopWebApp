using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BarbershopWebApp.Domain;
using BarbershopWebApp.Domain.Contracts;
using BarbershopWebApp.Domain.Models;

namespace BarbershopWebApp.BLL.Contracts
{
    public interface IBarberService
    {
        Task<IEnumerable<Barber>> GetAsync();
        Task<Barber> GetAsync(IBarberIdentity id);
        Task<Barber> CreateAsync(BarberUpdateModel barber);
        Task<Barber> UpdateAsync(BarberUpdateModel barber);
        Task ValidateAsync(IBarberContainer barberContainer);
    }
}