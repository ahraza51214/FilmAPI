using System;

namespace FilmApi.Data.DTOs.FranchiseDTOs
{
    // Definition of the FranchiseDTO class.
    public class FranchiseDTO
	{
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public FranchiseMovieDTO[] Movies { get; set; }
    }

    // Defining of the FranchiseMovieDTO which is used to get the movie id and title when getting a franchise.
    public class FranchiseMovieDTO
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; } = null!;
    }
}