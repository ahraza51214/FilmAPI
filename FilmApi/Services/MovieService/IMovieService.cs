using System;
using FilmApi.Data.Entities;

namespace FilmApi.Services.MovieService 
{
	public interface IMovieService : ICrudService<Movie, int>
	{
        Task UpdateCharactersInMovieAsync(int movieId, IEnumerable<int> characterIds);
    }
}

