using System;

namespace FilmApi.Data.DTOs.MovieDTOs
{
    // Definition of the MovieDTO class.
    public class MovieDTO
	{
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public int ReleaseYear { get; set; }
        public string Director { get; set; } = null!;
        public string? PictureUrl { get; set; }
        public string? TrailerUrl { get; set; }
        public int? FranchiseId { get; set; }
    }
}