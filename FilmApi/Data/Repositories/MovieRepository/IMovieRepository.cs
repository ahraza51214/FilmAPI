using System;
using FilmApi.Data.Entities;

namespace FilmApi.Data.Repositories.MovieRepository
{
	public interface IMovieRepository : ICrudRepository<Movie>
	{
	}
}