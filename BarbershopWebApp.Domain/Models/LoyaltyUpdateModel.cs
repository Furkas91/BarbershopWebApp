using BarbershopWebApp.Domain.Base;
using BarbershopWebApp.Domain.Contracts;

namespace BarbershopWebApp.Domain.Models
{
    public class LoyaltyUpdateModel:BaseLoyalty, ILoyaltyIdentity
    {
        public int Id { get; set; }
    }
}