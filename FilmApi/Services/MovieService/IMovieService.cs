using System;
using FilmApi.Data.Entities;

namespace FilmApi.Services.MovieService 
{
	internal interface IMovieService : ICrudService<Movie, int>
	{
	}
}

