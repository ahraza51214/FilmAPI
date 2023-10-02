using FilmApi.Data.DTOs.CharacterDTOs;
using System;
namespace FilmApi.Data.DTOs.MovieDTOs
{
    // Data Transfer Object to encapsulate the characters associated with a movie for client interaction.
    public class MovieGetCharactersDTO
	{
        // Collection of characters associated with the movie.
        public ICollection<CharacterDTO> Characters { get; set; }
    }
}

