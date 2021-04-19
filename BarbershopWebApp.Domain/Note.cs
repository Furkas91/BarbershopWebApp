using System;
using BarbershopWebApp.Domain.Base;
using BarbershopWebApp.Domain.Contracts;

namespace BarbershopWebApp.Domain
{
    public class Note:BaseNote, IConsumerContainer,IBarberContainer
    {
        public int Id { get; set; }
        
        public DateTime DateVisit { get; set; }
    }
}