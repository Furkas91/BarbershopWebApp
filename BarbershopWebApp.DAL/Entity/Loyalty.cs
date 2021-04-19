using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarbershopWebApp.DAL.Entity
{
    public class Loyalty
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Level { get; set; }
        public string Annotation { get; set;}
    }
}