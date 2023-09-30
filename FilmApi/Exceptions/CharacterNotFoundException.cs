using System;

namespace FilmApi.Exceptions
{
    // Custom exception class for handling cases where a character is not found.
    public class CharacterNotFoundException : Exception
    {
        // Constructor that takes the ID of the non-existent character and constructs an appropriate error message.
        public CharacterNotFoundException(int id) : base($"Character with ID: {id}, does not exist")
        {
            // The base constructor of the Exception class is called with a custom error message.
        }
    }
}