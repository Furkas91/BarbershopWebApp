using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarbershopWebApp.DAL.Entity
{
    public class Consumer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string MiddleName { get; set; }
        
        public string PhoneNumber{ get; set; }
        public int? loyaltyId { get; set; }
        public Loyalty Loyalty { get; set; }
        
        public List<Note> Notes { get; set; } = new List<Note>();
    }
}