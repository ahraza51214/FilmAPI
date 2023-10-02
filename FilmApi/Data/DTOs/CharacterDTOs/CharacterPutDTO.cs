using System;
namespace FilmApi.Data.DTOs.CharacterDTOs
{
    // Definition of the CharacterPutDTO class, to update a character.
    public class CharacterPutDTO
	{
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string? Alias { get; set; }
        public string Gender { get; set; } = null!;
        public string? PictureUrl { get; set; }
    }
}