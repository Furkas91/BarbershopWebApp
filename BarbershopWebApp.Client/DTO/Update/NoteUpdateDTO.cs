using BarbershopWebApp.Client.DTO.Create;

namespace BarbershopWebApp.Client.DTO.Update
{
    public class NoteUpdateDTO:NoteCreateDTO
    {
        public int Id { get; set; }
    }
}