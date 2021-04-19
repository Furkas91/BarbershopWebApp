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
    public class NoteService:INoteService
    {
        private INoteDAL NoteDAL { get; }
        private IConsumerService ConsumerService { get; }
        private IBarberService BarberService { get; }
        private IHaircutService HaircutService { get; }
        public NoteService(INoteDAL noteDAL, IConsumerService consumerService, IBarberService barberService, IHaircutService haircutService)
        {
            this.NoteDAL = noteDAL;
            this.ConsumerService = consumerService;
            this.BarberService = barberService;
            this.HaircutService = haircutService;
        }
        
        public async Task<Note> CreateAsync(NoteUpdateModel note) {
            await this.ConsumerService.ValidateAsync(note);
            await this.BarberService.ValidateAsync(note);
            await this.HaircutService.ValidateAsync(note);
            return await this.NoteDAL.InsertAsync(note);
        }
        
        public async Task<Note> UpdateAsync(NoteUpdateModel note) {
            return await this.NoteDAL.UpdateAsync(note);
        }
        
        public Task<IEnumerable<Note>> GetAsync() {
            return this.NoteDAL.GetAsync();
        }
        
        public Task<Note> GetAsync(INoteIdentity id)
        {
            return this.NoteDAL.GetAsync(id);
        }
    }
}