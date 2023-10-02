using System;

namespace FilmApi.Data.DTOs.FranchiseDTOs
{
    // Definition of the FranchisePutDTO class, to update a franchise.
    public class FranchisePutDTO
	{
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}