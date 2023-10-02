using System;
using FilmApi.Data;
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
            return await _context.Movies.Include(m => m.Characters).ToListAsync();
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


        // Update characters associated with a movie asynchronously.
        public async Task UpdateCharactersInMovieAsync(int movieId, IEnumerable<int> characterIds)
        {
            // Check if the movie with the given ID exists.
            if (!await MovieExists(movieId))
            {
                // Throw an exception if the movie is not found.
                throw new MovieNotFoundException(movieId);
            }

            // Retrieve the movie with its associated characters from the database.
            var movie = await _context.Movies.Include(m => m.Characters).FirstOrDefaultAsync(m => m.Id == movieId);

            // Fetch characters associated with the given characterIds from the database.
            var associatedCharactersList = await _context.Characters
                .Where(c => characterIds.Contains(c.Id))
                .ToListAsync();

            // Clear the current associations and reset them.
            // movie.Characters.Clear();

            // Add the fetched characters to the movie's character collection.
            foreach (var character in associatedCharactersList)
            {
                movie.Characters.Add(character);
            }

            // Save changes to the database.
            await _context.SaveChangesAsync();
        }


        // Get all characters associated with a movie asynchronously.
        public async Task<IEnumerable<Character>> GetCharactersInMovieAsync(int movieId)
        {
            // Check if the movie with the given ID exists.
            if (!await MovieExists(movieId))
            {
                // Throw an exception if the movie is not found.
                throw new MovieNotFoundException(movieId);
            }

            // Retrieve the movie with its associated characters from the database.
            var movie = await _context.Movies.Include(m => m.Characters)
                                         .FirstOrDefaultAsync(m => m.Id == movieId);

            // Return the list of characters associated with the movie.
            return movie?.Characters.ToList();
        }


        // Check if a movie with a given ID exists in the database.
        private async Task<bool> MovieExists(int id)
        {
            return await _context.Movies.AnyAsync(e => e.Id == id);
        }
    }
}