using System;

namespace FilmApi.Exceptions
{
    // Custom exception class for handling cases where a franchise is not found.
    public class FranchiseNotFoundException : Exception
    {
        // Constructor that takes the ID of the non-existent franchise and constructs an appropriate error message.
        public FranchiseNotFoundException(int id) : base($"Franchise with ID: {id}, does not exist")
        {
            // The base constructor of the Exception class is called with a custom error message.
        }
    }
}