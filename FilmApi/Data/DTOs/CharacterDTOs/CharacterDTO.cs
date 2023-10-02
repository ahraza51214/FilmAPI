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
        public CharacterMovieDTO[] Movies { get; set; }
    }

    // Defining of the CharacterMovieDTO which is used to get the movie id and title when getting a character.
    public class CharacterMovieDTO
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
    }
}