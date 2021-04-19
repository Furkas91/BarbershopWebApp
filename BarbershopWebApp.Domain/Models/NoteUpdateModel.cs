using BarbershopWebApp.Domain.Base;
using BarbershopWebApp.Domain.Contracts;

namespace BarbershopWebApp.Domain.Models
{
    public class NoteUpdateModel:BaseNote, INoteIdentity, IConsumerContainer,IBarberContainer, IHaircutContainer
    {
        public int Id { get; set; }
        
    }
}