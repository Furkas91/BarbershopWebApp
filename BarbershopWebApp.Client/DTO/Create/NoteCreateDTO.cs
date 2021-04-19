using System.ComponentModel.DataAnnotations;
using BarbershopWebApp.Domain;

namespace BarbershopWebApp.Client.DTO.Create
{
    public class NoteCreateDTO
    {
        [Required(ErrorMessage = "BarberId is required")]
        public int BarberId { get; set; }
        [Required(ErrorMessage = "ConsumerId is required")]
        public int ConsumerId { get; set; }
        [Required(ErrorMessage = "HaircutId is required")]
        public int HaircutId { get; set; }
    }
}