using BarbershopWebApp.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BarbershopWebApp.DAL.Contracts;
using BarbershopWebApp.DAL.Entity;
using BarbershopWebApp.Domain.Contracts;
using BarbershopWebApp.Domain.Models;

namespace BarbershopWebApp.DAL.Implementations
{
    public class HaircutDAL:IHaircutDAL
    {
        private AppContext Context { get; }
        private IMapper Mapper { get; }
        
        public HaircutDAL(AppContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<BarbershopWebApp.Domain.Haircut> InsertAsync(HaircutUpdateModel haircut)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<Haircut>(haircut));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<BarbershopWebApp.Domain.Haircut>(result.Entity);
        }

        public async Task<IEnumerable<BarbershopWebApp.Domain.Haircut>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<BarbershopWebApp.Domain.Haircut>>(
                await this.Context.Haircut.ToListAsync());
        }

        public async Task<BarbershopWebApp.Domain.Haircut> GetAsync(IHaircutIdentity haircut)
        {
            var result = await this.Get(haircut);

            return this.Mapper.Map<BarbershopWebApp.Domain.Haircut>(result);
        }

        private async Task<Haircut> Get(IHaircutIdentity haircut)
        {
            if (haircut == null)
            {
                throw new ArgumentNullException(nameof(haircut));
            }
            
            return await this.Context.Haircut.FirstOrDefaultAsync(x => x.Id == haircut.Id);
        }

        public async Task<BarbershopWebApp.Domain.Haircut> UpdateAsync(HaircutUpdateModel haircut)
        {
            var existing = await this.Get(haircut);

            var result = this.Mapper.Map(haircut, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<BarbershopWebApp.Domain.Haircut>(result);
        }
    }
}