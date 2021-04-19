using BarbershopWebApp.Domain.Contracts;

namespace BarbershopWebApp.Domain.Models
{
    public class HaircutIdentityModel:IHaircutIdentity
    {
        public int Id { get; }

        public HaircutIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}