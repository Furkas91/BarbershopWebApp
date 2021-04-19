using BarbershopWebApp.Client.DTO.Create;

namespace BarbershopWebApp.Client.DTO.Update
{
    public class BarberUpdateDto:BarberCreateDTO
    {
        public int Id { get; set; }
    }
}