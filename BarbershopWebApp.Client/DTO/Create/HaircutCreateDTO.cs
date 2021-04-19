using System.ComponentModel.DataAnnotations;

namespace BarbershopWebApp.Client.DTO.Create
{
    public class HaircutCreateDTO
    {
        [Required(ErrorMessage = "Type is required")]
        public string Type { get; set; }
        public string Description { get; set;}
        public int Price { get; set;}
        public string Annotation { get; set;}
    }
}