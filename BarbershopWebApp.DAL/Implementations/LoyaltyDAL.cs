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
    public class LoyaltyDAL:ILoyaltyDAL
    {
        private AppContext Context { get; }
        private IMapper Mapper { get; }
        
        public LoyaltyDAL(AppContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<BarbershopWebApp.Domain.Loyalty> InsertAsync(LoyaltyUpdateModel loyalty)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<Loyalty>(loyalty));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<BarbershopWebApp.Domain.Loyalty>(result.Entity);
        }

        public async Task<IEnumerable<BarbershopWebApp.Domain.Loyalty>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<BarbershopWebApp.Domain.Loyalty>>(
                await this.Context.Loyalties.ToListAsync());
        }

        public async Task<BarbershopWebApp.Domain.Loyalty> GetAsync(ILoyaltyIdentity loyalty)
        {
            var result = await this.Get(loyalty);

            return this.Mapper.Map<BarbershopWebApp.Domain.Loyalty>(result);
        }

        private async Task<Loyalty> Get(ILoyaltyIdentity loyalty)
        {
            if (loyalty == null)
            {
                throw new ArgumentNullException(nameof(loyalty));
            }
            
            return await this.Context.Loyalties.FirstOrDefaultAsync(x => x.Id == loyalty.Id);
        }

        public async Task<BarbershopWebApp.Domain.Loyalty> UpdateAsync(LoyaltyUpdateModel loyalty)
        {
            var existing = await this.Get(loyalty);

            var result = this.Mapper.Map(loyalty, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<BarbershopWebApp.Domain.Loyalty>(result);
        }
    }
}