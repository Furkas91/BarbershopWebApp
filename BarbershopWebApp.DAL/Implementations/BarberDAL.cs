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
    public class BarberDAL:IBarberDAL
    {
        private AppContext Context { get; }
        private IMapper Mapper { get; }
        
        public BarberDAL(AppContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<BarbershopWebApp.Domain.Barber> InsertAsync(BarberUpdateModel barber)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<Barber>(barber));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<BarbershopWebApp.Domain.Barber>(result.Entity);
        }

        public async Task<IEnumerable<BarbershopWebApp.Domain.Barber>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<BarbershopWebApp.Domain.Barber>>(
                await this.Context.Barbers.ToListAsync());
        }

        public async Task<BarbershopWebApp.Domain.Barber> GetAsync(IBarberIdentity barber)
        {
            var result = await this.Get(barber);

            return this.Mapper.Map<BarbershopWebApp.Domain.Barber>(result);
        }

        private async Task<Barber> Get(IBarberIdentity barber)
        {
            if (barber == null)
            {
                throw new ArgumentNullException(nameof(barber));
            }
            
            return await this.Context.Barbers.FirstOrDefaultAsync(x => x.Id == barber.Id);
        }

        public async Task<BarbershopWebApp.Domain.Barber> UpdateAsync(BarberUpdateModel barber)
        {
            var existing = await this.Get(barber);

            var result = this.Mapper.Map(barber, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<BarbershopWebApp.Domain.Barber>(result);
        }
    }
}