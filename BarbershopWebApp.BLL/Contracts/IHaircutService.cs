using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BarbershopWebApp.Domain;
using BarbershopWebApp.Domain.Contracts;
using BarbershopWebApp.Domain.Models;

namespace BarbershopWebApp.BLL.Contracts
{
    public interface IHaircutService
    {
        Task<IEnumerable<Haircut>> GetAsync();
        Task<Haircut> GetAsync(IHaircutIdentity id);
        Task<Haircut> CreateAsync(HaircutUpdateModel haircut);
        Task<Haircut> UpdateAsync(HaircutUpdateModel haircut);
        Task ValidateAsync(IHaircutContainer haircutContainer);
    }
}