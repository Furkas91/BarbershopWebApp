using System.Collections.Generic;
using System.Threading.Tasks;
using BarbershopWebApp.Domain;
using BarbershopWebApp.Domain.Contracts;
using BarbershopWebApp.Domain.Models;

namespace BarbershopWebApp.DAL.Contracts
{
    public interface IBarberDAL
    {
        Task<Barber> InsertAsync(BarberUpdateModel barber);
        Task<IEnumerable<Barber>> GetAsync();
        Task<Barber> GetAsync(IBarberIdentity barberId);
        Task<Barber> UpdateAsync(BarberUpdateModel barber);
    }
}