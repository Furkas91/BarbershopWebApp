using System.Collections.Generic;
using System.Threading.Tasks;
using BarbershopWebApp.Domain;
using BarbershopWebApp.Domain.Contracts;
using BarbershopWebApp.Domain.Models;

namespace BarbershopWebApp.DAL.Contracts
{
    public interface IHaircutDAL
    {
        Task<Haircut> InsertAsync(HaircutUpdateModel haircut);
        Task<IEnumerable<Haircut>> GetAsync();
        Task<Haircut> GetAsync(IHaircutIdentity haircutId);
        Task<Haircut> UpdateAsync(HaircutUpdateModel haircut);
    }
}