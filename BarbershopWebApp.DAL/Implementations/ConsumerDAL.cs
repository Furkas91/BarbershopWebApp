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
    public class ConsumerDAL:IConsumerDAL 
    {
        private AppContext Context { get; }
        private IMapper Mapper { get; }
        
        public ConsumerDAL(AppContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<BarbershopWebApp.Domain.Consumer> InsertAsync(ConsumerUpdateModel consumer)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<Consumer>(consumer));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<BarbershopWebApp.Domain.Consumer>(result.Entity);
        }

        public async Task<IEnumerable<BarbershopWebApp.Domain.Consumer>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<BarbershopWebApp.Domain.Consumer>>(
                await this.Context.Consumers.ToListAsync());
        }

        public async Task<BarbershopWebApp.Domain.Consumer> GetAsync(IConsumerIdentity consumer)
        {
            var result = await this.Get(consumer);

            return this.Mapper.Map<BarbershopWebApp.Domain.Consumer>(result);
        }

        private async Task<Consumer> Get(IConsumerIdentity consumer)
        {
            if (consumer == null)
            {
                throw new ArgumentNullException(nameof(consumer));
            }
            
            return await this.Context.Consumers.FirstOrDefaultAsync(x => x.Id == consumer.Id);
        }

        public async Task<BarbershopWebApp.Domain.Consumer> UpdateAsync(ConsumerUpdateModel consumer)
        {
            var existing = await this.Get(consumer);

            var result = this.Mapper.Map(consumer, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<BarbershopWebApp.Domain.Consumer>(result);
        }
    }
}