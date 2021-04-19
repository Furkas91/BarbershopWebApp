using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarbershopWebApp.DAL.Entity
{
    public class Note
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int barberId { get; set; }
        public Barber Barber { get; set; }
        public int consumerId { get; set; }
        public Consumer Consumer { get; set; }
        public int? haircutId { get; set; }
        public Haircut Haircut { get; set; }
        public DateTime DateVisit { get; set; }
    }
}