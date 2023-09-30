using System;
using FilmApi.Data.Entities;

namespace FilmApi.Services.MovieService
{
    // Interface for Movie-related methods that extends the ICrudService interface.
    public interface IMovieService : ICrudService<Movie, int>
    {
        // Asynchronously get all characters associated with a movie by its ID.
        Task<IEnumerable<Character>> GetCharactersInMovieAsync(int movieId);

        // Asynchronously update characters associated with a movie by its ID with the given character IDs.
        Task UpdateCharactersInMovieAsync(int movieId, IEnumerable<int> characterIds);
    }
}