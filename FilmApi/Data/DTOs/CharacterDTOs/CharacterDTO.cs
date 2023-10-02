using System;
namespace FilmApi.Data.DTOs.CharacterDTOs
{
    // Definition of the CharacterDTO class.
    public class CharacterDTO
	{
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string? Alias { get; set; }
        public string Gender { get; set; } = null!;
        public string? PictureUrl { get; set; }
        public int[] Movies { get; set; }
        public string[] MovieTitles { get; set; }
    }
}