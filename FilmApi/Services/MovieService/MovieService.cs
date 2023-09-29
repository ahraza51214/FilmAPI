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
            return await _context.Movies.FindAsync(id);
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

            var franchise = await _context.Franchises.FindAsync(id);
            if (franchise == null)
            {
                throw new MovieNotFoundException(id);
            }
            _context.Franchises.Remove(franchise);
            await _context.SaveChangesAsync();
        }

        private async Task<bool> MovieExists(int id)
        {
            return await _context.Movies.AnyAsync(e => e.Id == id);
        }
    }
}