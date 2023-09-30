using System;
using FilmApi.Data.Entities;

namespace FilmApi.Services.FranchiseService
{
	public interface IFranchiseService : ICrudService<Franchise, int>
	{
        Task<IEnumerable<Movie>> GetMoviesInFranchiseAsync(int franchiseId);
        Task UpdateMoviesInFranchiseAsync(int franchiseId, IEnumerable<int> movieIds);
        Task<IEnumerable<Character>> GetCharactersInFranchiseAsync(int franchiseId);
    }
}