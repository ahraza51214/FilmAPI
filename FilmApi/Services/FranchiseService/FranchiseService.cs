using System;
using FilmApi.Data;
using FilmApi.Data.Entities;
using FilmApi.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace FilmApi.Services.FranchiseService
{
	public class FranchiseService : IFranchiseService
	{
        private readonly MovieDbContext _context;

        public FranchiseService(MovieDbContext context)
		{
            _context = context;
		}


        public async Task<IEnumerable<Franchise>> GetAllAsync()
        {
            return await _context.Franchises.ToListAsync();
        }


        public async Task<Franchise?> GetByIdAsync(int id)
        {
            var franchise = await _context.Franchises.FindAsync(id);
            if (franchise is null)
            {
                throw new FranchiseNotFoundException(id);
            }
            return franchise;
        }


        public async Task<Franchise> UpdateAsync(Franchise obj)
        {
            if (!await FranchiseExists(obj.Id))
            {
                throw new FranchiseNotFoundException(obj.Id);
            }

            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();

            return obj;
        }


        public async Task<Franchise> AddAsync(Franchise obj)
        {
            await _context.Franchises.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }


        public async Task DeleteAsync(int id)
        {
            // Early exit if prof doesnt exist
            if (!await FranchiseExists(id))
            {
                throw new FranchiseNotFoundException(id);
            }

            var franchise = await _context.Franchises.FindAsync(id);
            if (franchise == null)
            {
                throw new FranchiseNotFoundException(id);
            }
            _context.Franchises.Remove(franchise);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateMoviesInFranchiseAsync(int franchiseId, IEnumerable<int> movieIds)
        {
            if (!await FranchiseExists(franchiseId))
            {
                throw new FranchiseNotFoundException(franchiseId);
            }

            var franchise = await _context.Franchises.Include(f => f.Movies).FirstOrDefaultAsync(f => f.Id == franchiseId);

            // Fetch characters associated with the given characterIds
            var associatedMoviesList = await _context.Movies
                .Where(m => movieIds
                .Contains(m.Id))
                .ToListAsync();

            // Clear the current associations and reset them
            franchise.Movies.Clear();

            foreach (var movie in associatedMoviesList)
            {
                franchise.Movies.Add(movie);
            }
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Movie>> GetMoviesInFranchiseAsync(int franchiseId)
        {
            if (!await FranchiseExists(franchiseId))
            {
                throw new FranchiseNotFoundException(franchiseId);
            }

            var franchise = await _context.Franchises.Include(f => f.Movies)
                                                .FirstOrDefaultAsync(f => f.Id == franchiseId);

            return franchise?.Movies.ToList();
        }


        public async Task<IEnumerable<Character>> GetCharactersInFranchiseAsync(int franchiseId)
        {
            if (!await FranchiseExists(franchiseId))
            {
                throw new FranchiseNotFoundException(franchiseId);
            }

            var franchise = await _context.Franchises.Include(f => f.Movies)
                                                    .ThenInclude(m => m.Characters)
                                                    .FirstOrDefaultAsync(f => f.Id == franchiseId);

            return franchise.Movies.SelectMany(m => m.Characters).ToList();
        }


        private async Task<bool> FranchiseExists(int id)
        {
            return await _context.Franchises.AnyAsync(e => e.Id == id);
        }
    }
}