using System.ComponentModel.DataAnnotations;

namespace BarbershopWebApp.Client.DTO.Create
{
    public class BarberCreateDTO
    {
        [Required(ErrorMessage = "FullName is required")]
        public string FullName { get; set; }
        public string ProfessionalLevel { get; set; }
    }
}