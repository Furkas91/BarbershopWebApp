using BarbershopWebApp.Domain.Contracts;

namespace BarbershopWebApp.Domain.Models
{
    public class BarberIdentityModel:IBarberIdentity
    {
        public int Id { get; }

        public BarberIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}