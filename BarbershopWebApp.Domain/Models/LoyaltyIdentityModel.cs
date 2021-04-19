using BarbershopWebApp.Domain.Contracts;

namespace BarbershopWebApp.Domain.Models
{
    public class LoyaltyIdentityModel:ILoyaltyIdentity
    {
        public int Id { get; }

        public LoyaltyIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}