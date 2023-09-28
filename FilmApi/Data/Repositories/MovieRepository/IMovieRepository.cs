using System;
using FilmApi.Data.Entities;

namespace FilmApi.Data.Repositories.MovieRepository
{
	internal interface IMovieRepository : ICrudRepository<Movie>
	{
	}
}