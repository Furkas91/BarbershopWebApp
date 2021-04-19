using BarbershopWebApp.Domain.Base;
using BarbershopWebApp.Domain.Contracts;

namespace BarbershopWebApp.Domain.Models
{
    public class HaircutUpdateModel: BaseHaircut, IHaircutIdentity
    {
        public int Id { get; set; }
    }
}