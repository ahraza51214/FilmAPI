using System;
namespace FilmApi.Services.Exceptions
{
	public class MovieNotFoundException : Exception
	{
		public MovieNotFoundException(int id) : base($"Movie with ID: {id}, does not exist")
        {
		}
	}
}