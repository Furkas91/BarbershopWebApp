using BarbershopWebApp.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BarbershopWebApp.DAL.Contracts;
using BarbershopWebApp.Domain.Contracts;
using BarbershopWebApp.Domain.Models;
using Note = BarbershopWebApp.DAL.Entity.Note;

namespace BarbershopWebApp.DAL.Implementations
{
    public class NoteDAL:INoteDAL
    {
        private AppContext Context { get; }
        private IMapper Mapper { get; }
        
        public NoteDAL(AppContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<BarbershopWebApp.Domain.Note> InsertAsync(NoteUpdateModel note)
        {
            Note new_obj = this.Mapper.Map<Note>(note);
            new_obj.DateVisit = DateTime.Today;
            var result = await this.Context.AddAsync(new_obj);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<BarbershopWebApp.Domain.Note>(result.Entity);
        }

        public async Task<IEnumerable<BarbershopWebApp.Domain.Note>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<BarbershopWebApp.Domain.Note>>(
                await this.Context.Note.ToListAsync());
        }

        public async Task<BarbershopWebApp.Domain.Note> GetAsync(INoteIdentity note)
        {
            var result = await this.Get(note);

            return this.Mapper.Map<BarbershopWebApp.Domain.Note>(result);
        }

        private async Task<Note> Get(INoteIdentity note)
        {
            if (note == null)
            {
                throw new ArgumentNullException(nameof(note));
            }
            
            return await this.Context.Note.FirstOrDefaultAsync(x => x.Id == note.Id);
        }

        public async Task<BarbershopWebApp.Domain.Note> UpdateAsync(NoteUpdateModel note)
        {
            var existing = await this.Get(note);
            
            var result = this.Mapper.Map(note, existing);
            
            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<BarbershopWebApp.Domain.Note>(result);
        }
    }
}