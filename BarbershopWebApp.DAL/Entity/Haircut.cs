using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarbershopWebApp.DAL.Entity
{
    public class Haircut
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set;}
        public int Price { get; set;}
        public string Annotation { get; set;}
    }
}