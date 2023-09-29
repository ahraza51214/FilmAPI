using System;
namespace FilmApi.Services.Exceptions
{
	public class CharacterNotFoundException : Exception
	{
		public CharacterNotFoundException(int id) : base($"Character with ID: {id}, does not exist")
		{
		}
	}
}