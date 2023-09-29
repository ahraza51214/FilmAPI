using System;
namespace FilmApi.Services.Exceptions
{
	public class FranchiseNotFoundException : Exception
	{
		public FranchiseNotFoundException(int id) : base($"Franchise with ID: {id}, does not exist")
        {
		}
	}
}