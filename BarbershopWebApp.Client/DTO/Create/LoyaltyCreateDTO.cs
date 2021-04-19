using System.ComponentModel.DataAnnotations;

namespace BarbershopWebApp.Client.DTO.Create
{
    public class LoyaltyCreateDTO
    {
        [Required(ErrorMessage = "Level is required")]
        public string Level { get; set; }
        public string Annotation { get; set;}
    }
}