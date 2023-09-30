using System;

namespace FilmApi.Exceptions
{
    // Custom exception class for handling cases where a movie is not found.
    public class MovieNotFoundException : Exception
    {
        // Constructor that takes the ID of the non-existent movie and constructs an appropriate error message.
        public MovieNotFoundException(int id) : base($"Movie with ID: {id}, does not exist")
        {
            // The base constructor of the Exception class is called with a custom error message.
        }
    }
}