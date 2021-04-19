using System.Collections.Generic;
using System.Threading.Tasks;
using BarbershopWebApp.Domain;
using BarbershopWebApp.Domain.Contracts;
using BarbershopWebApp.Domain.Models;

namespace BarbershopWebApp.DAL.Contracts
{
    public interface INoteDAL
    {
        Task<Note> InsertAsync(NoteUpdateModel note);
        Task<IEnumerable<Note>> GetAsync();
        Task<Note> GetAsync(INoteIdentity noteId);
        Task<Note> UpdateAsync(NoteUpdateModel note);
    }
}