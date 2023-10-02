using System;

namespace FilmApi.Data.DTOs.FranchiseDTOs
{
    // Definition of the FranchisePostDTO class, to create a new franchise.
    public class FranchisePostDTO
	{
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}