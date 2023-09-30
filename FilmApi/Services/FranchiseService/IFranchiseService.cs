using System;
using FilmApi.Data.Entities;

namespace FilmApi.Services.FranchiseService
{
    // Interface for Franchise-related methods that extends the ICrudService interface.
    public interface IFranchiseService : ICrudService<Franchise, int>
    {
        // Asynchronously get all movies associated with a franchise by its ID.
        Task<IEnumerable<Movie>> GetMoviesInFranchiseAsync(int franchiseId);

        // Asynchronously update movies associated with a franchise by its ID with the given movie IDs.
        Task UpdateMoviesInFranchiseAsync(int franchiseId, IEnumerable<int> movieIds);

        // Asynchronously get all characters associated with all the movies in a franchise by its ID.
        Task<IEnumerable<Character>> GetCharactersInFranchiseAsync(int franchiseId);
    }
}