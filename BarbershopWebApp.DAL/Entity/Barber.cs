using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarbershopWebApp.DAL.Entity
{
    public class Barber
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string FullName { get; set; }

        public string ProfessionalLevel { get; set; }
        
        public List<Barber> Users { get; set; } = new List<Barber>();
    }
}