using System;

namespace BarbershopWebApp.Domain.Base
{
    public class BaseNote
    {
        public int? ConsumerId { get; set; }
        public int? BarberId { get; set; }
        
        public int? HaircutId { get; set; }
    
    }
}