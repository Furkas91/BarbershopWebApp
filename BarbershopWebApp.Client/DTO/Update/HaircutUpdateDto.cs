using BarbershopWebApp.Client.DTO.Create;

namespace BarbershopWebApp.Client.DTO.Update
{
    public class HaircutUpdateDto: HaircutCreateDTO
    {
        public int Id { get; set; }
    }
}