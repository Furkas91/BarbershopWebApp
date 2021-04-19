using BarbershopWebApp.Domain.Base;
using BarbershopWebApp.Domain.Contracts;

namespace BarbershopWebApp.Domain
{
    public class Consumer:BaseConsumer,ILoyaltyContainer
    {
        
        public int Id { get; set; }
        public int? LoyaltyId { get; set; }
    }
}