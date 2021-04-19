using BarbershopWebApp.Domain.Base;
using BarbershopWebApp.Domain.Contracts;

namespace BarbershopWebApp.Domain.Models
{
    public class BarberUpdateModel:BaseBarber, IBarberIdentity
    {
        public int Id { get; set; }
    }
}