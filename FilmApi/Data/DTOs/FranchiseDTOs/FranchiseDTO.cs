using System;

namespace FilmApi.Data.DTOs.FranchiseDTOs
{
    // Definition of the FranchiseDTO class.
    public class FranchiseDTO
	{
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}