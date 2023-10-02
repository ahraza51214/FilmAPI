using System;
namespace FilmApi.Data.DTOs.CharacterDTOs
{
    // Definition of the CharacterPostDTO class, to create a new character.
    public class CharacterPostDTO
	{
        public string FullName { get; set; } = null!;
        public string? Alias { get; set; }
        public string Gender { get; set; } = null!;
        public string? PictureUrl { get; set; }
    }
}