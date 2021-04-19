using BarbershopWebApp.Domain.Base;
using BarbershopWebApp.Domain.Contracts;

namespace BarbershopWebApp.Domain.Models
{
    public class ConsumerUpdateModel: BaseConsumer, IConsumerIdentity, ILoyaltyContainer
    {
        public int Id { get; set; }
        public int? LoyaltyId { get; set; }
    }
}