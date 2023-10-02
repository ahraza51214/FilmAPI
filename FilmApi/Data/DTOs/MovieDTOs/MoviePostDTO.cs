using System;

namespace FilmApi.Data.DTOs.MovieDTOs
{
    // Definition of the MoviePostDTO class, to create a new movie.
    public class MoviePostDTO
	{
        public string Title { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public int ReleaseYear { get; set; }
        public string Director { get; set; } = null!;
        public string? PictureUrl { get; set; }
        public string? TrailerUrl { get; set; }
    }
}