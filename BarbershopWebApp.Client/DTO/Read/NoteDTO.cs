using System;
using BarbershopWebApp.Client.DTO.Create;
using BarbershopWebApp.Domain;

namespace BarbershopWebApp.Client.DTO.Read
{
    public class NoteDTO
    {
        public int Id { get; set; }
        public int BarberId { get; set; }
        public int ConsumerId { get; set; }
        public int HaircutId { get; set; }
        public DateTime DateVisit { get; set; }
    }
}