using BarbershopWebApp.Domain.Contracts;

namespace BarbershopWebApp.Domain.Models
{
    public class ConsumerIdentityModel:IConsumerIdentity
    {
        public int Id { get; }

        public ConsumerIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}