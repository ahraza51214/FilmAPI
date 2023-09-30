using System;
using FilmApi.Data;
using FilmApi.Data.Entities;
using FilmApi.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace FilmApi.Services.MovieService
{
	public class MovieService : IMovieService
	{
        private readonly MovieDbContext _context;

        public MovieService(MovieDbContext context)
		{
            _context = context;
		}

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie is null)
            {
                throw new MovieNotFoundException(id);
            }
            return movie;
        }

        public async Task<Movie> UpdateAsync(Movie obj)
        {
            if (!await MovieExists(obj.Id))
            {
                throw new MovieNotFoundException(obj.Id);
            }

            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();

            return obj;
        }

        public async Task<Movie> AddAsync(Movie obj)
        {
            await _context.Movies.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task DeleteAsync(int id)
        {
            // Early exit if prof doesnt exist
            if (!await MovieExists(id))
            {
                throw new MovieNotFoundException(id);
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                throw new MovieNotFoundException(id);
            }
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }

      
        // Get all the characters in a movie. 
        public async Task<IEnumerable<Character>> GetCharactersInMovieAsync(int movieId)
        {
            if (!await MovieExists(movieId))
            {
                throw new MovieNotFoundException(movieId);
            }

            var movie = await _context.Movies.Include(m => m.Characters)
                                         .FirstOrDefaultAsync(m => m.Id == movieId);

            return movie?.Characters.ToList();
        }


        public async Task UpdateCharactersInMovieAsync(int movieId, IEnumerable<int> characterIds)
        {
            if (!await MovieExists(movieId))
            {
                throw new MovieNotFoundException(movieId);
            }

            var movie = await _context.Movies.Include(m => m.Characters).FirstOrDefaultAsync(m => m.Id == movieId);

            // Fetch characters associated with the given characterIds
            var associatedCharacters = await _context.Characters
                .Where(c => characterIds
                .Contains(c.Id))
                .ToListAsync();

            // Clear the current associations and reset them
            // movie.Characters.Clear();

            foreach (var character in associatedCharacters)
            {
                movie.Characters.Add(character);
            }

            await _context.SaveChangesAsync();
        }


        private async Task<bool> MovieExists(int id)
        {
            return await _context.Movies.AnyAsync(e => e.Id == id);
        }
    }
}