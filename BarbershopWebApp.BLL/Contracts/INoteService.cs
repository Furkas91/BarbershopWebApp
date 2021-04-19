using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BarbershopWebApp.Domain;
using BarbershopWebApp.Domain.Contracts;
using BarbershopWebApp.Domain.Models;

namespace BarbershopWebApp.BLL.Contracts
{
    public interface INoteService
    {
        Task<IEnumerable<Note>> GetAsync();
        Task<Note> GetAsync(INoteIdentity id);
        Task<Note> CreateAsync(NoteUpdateModel note);
        Task<Note> UpdateAsync(NoteUpdateModel note);
    }
}