using System;
using FilmApi.Data;
using FilmApi.Data.DTOs.MovieDTOs;
using FilmApi.Data.Entities;
using FilmApi.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace FilmApi.Services.MovieService
{
    // Implementation of the IMovieService interface for movie-related methods.
    public class MovieService : IMovieService
    {
        // Database context for movie-related methods.
        private readonly MovieDbContext _context;

        // Constructor to initialize the MovieService with a MovieDbContext.
        public MovieService(MovieDbContext context)
        {
            _context = context;
        }

        // Get all movies asynchronously.
        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _context.Movies.Include(c => c.Characters).ToListAsync();
        }

        // Get a movie by its ID asynchronously.
        public async Task<Movie?> GetByIdAsync(int id)
        {
            var movie = await _context.Movies.Where(m => m.Id == id).Include(m => m.Characters).FirstAsync(); 
            if (movie is null)
            {
                // Throw an exception if the movie with the specified ID is not found.
                throw new MovieNotFoundException(id);
            }
            return movie;
        }

        // Update a movie asynchronously.
        public async Task<Movie> UpdateAsync(Movie obj)
        {
            // Check if the movie with the given ID exists.
            if (!await MovieExists(obj.Id))
            {
                // Throw an exception if the movie is not found.
                throw new MovieNotFoundException(obj.Id);
            }

            // Mark the movie entity as modified and save changes to the database.
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();

            return obj;
        }

        // Add a new movie asynchronously.
        public async Task<Movie> AddAsync(Movie obj)
        {
            // Add the movie to the database and save changes.
            await _context.Movies.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        // Delete a movie by ID asynchronously.
        public async Task DeleteAsync(int id)
        {
            // Check if the movie with the given ID exists.
            if (!await MovieExists(id))
            {
                // Throw an exception if the movie is not found.
                throw new MovieNotFoundException(id);
            }

            // Find and remove the movie from the database.
            var movie = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }
        
        public async Task UpdateCharactersInMovieAsync(int movieId, IEnumerable<int> characterIds)
        {
            // Check if the movie with the given ID exists in the database.
            if (!await MovieExists(movieId))
            {
                // If the movie doesn't exist, throw a custom exception.
                throw new MovieNotFoundException(movieId);
            }

            // Retrieve the movie with the given ID from the database and include its associated characters.
            var movie = await _context.Movies.Include(m => m.Characters).FirstOrDefaultAsync(m => m.Id == movieId);

            // If for some reason the movie is null (even if it existed earlier), throw an exception.
            // This is an edge case but good to handle.
            if (movie is null)
            {
                throw new Exception($"Retrieved movie with ID {movieId} is null.");
            }

            // Fetch the characters from the database that match the provided character IDs.
            var associatedCharactersList = await _context.Characters
                .Where(c => characterIds.Contains(c.Id))
                .ToListAsync();

            // Clear the current list of characters associated with the movie.
            //movie.Characters.Clear();

            // Add each character from the fetched list to the movie's character collection.
            foreach (var character in associatedCharactersList)
            {
                movie.Characters.Add(character);
            }

            // Save the changes to the database.
            await _context.SaveChangesAsync();
        }





        /// <summary>
        /// Asynchronously retrieves a movie and its associated characters from the database.
        /// </summary>
        /// <param name="movieId">Unique ID of the movie.</param>
        /// <returns>Movie entity with its associated characters.</returns>
        /// <exception cref="MovieNotFoundException"></exception>
        public async Task<Movie> GetCharactersInMovieAsync(int movieId)
        {
            // Check if the movie with the given ID exists.
            if (!await MovieExists(movieId))
            {
                // Throw an exception if the movie is not found.
                throw new MovieNotFoundException(movieId);
            }

            // Fetch the movie and its associated characters.
            var movie = await _context.Movies.Include(m => m.Characters).FirstOrDefaultAsync(m => m.Id == movieId);

            if (movie == null)
            {
                throw new MovieNotFoundException(movieId);
            }

            return movie;
        }


        // Check if a movie with a given ID exists in the database.
        private async Task<bool> MovieExists(int id)
        {
            return await _context.Movies.AnyAsync(e => e.Id == id);
        }
    }
}
