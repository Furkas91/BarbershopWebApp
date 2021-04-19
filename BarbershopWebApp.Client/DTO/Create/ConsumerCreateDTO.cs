using System.ComponentModel.DataAnnotations;

namespace BarbershopWebApp.Client.DTO.Create
{
    public class ConsumerCreateDTO
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        
        public string MiddleName { get; set; }
        
        [Required(ErrorMessage = "Phone is required")]
        public string PhoneNumber{ get; set; }
        [Required(ErrorMessage = "LoyaltyId is required")]
        public int LoyaltyId { get; set; }
    }
}