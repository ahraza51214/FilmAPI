using System;
using FilmApi.Data;
using FilmApi.Data.Entities;
using FilmApi.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace FilmApi.Services.FranchiseService
{
    // Implementation of the IFranchiseService interface for franchise-related methods.
    public class FranchiseService : IFranchiseService
    {
        // Database context for franchise-related methods.
        private readonly MovieDbContext _context;

        // Constructor to initialize the FranchiseService with a MovieDbContext.
        public FranchiseService(MovieDbContext context)
        {
            _context = context;
        }


        // Get all franchises asynchronously.
        public async Task<IEnumerable<Franchise>> GetAllAsync()
        {
            return await _context.Franchises.Include(f => f.Movies).ToListAsync();
        }


        // Get a franchise by its ID asynchronously.
        public async Task<Franchise?> GetByIdAsync(int id)
        {
            var franchise = await _context.Franchises.Where(f => f.Id == id).Include(f => f.Movies).FirstAsync();
            if (franchise is null)
            {
                // Throw an exception if the franchise with the specified ID is not found.
                throw new FranchiseNotFoundException(id);
            }
            return franchise;
        }


        // Update a franchise asynchronously.
        public async Task<Franchise> UpdateAsync(Franchise obj)
        {
            // Check if the franchise with the given ID exists.
            if (!await FranchiseExists(obj.Id))
            {
                // Throw an exception if the franchise is not found.
                throw new FranchiseNotFoundException(obj.Id);
            }

            // Mark the franchise entity as modified and save changes to the database.
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();

            return obj;
        }


        // Add a new franchise asynchronously.
        public async Task<Franchise> AddAsync(Franchise obj)
        {
            // Add the franchise to the database and save changes.
            await _context.Franchises.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }


        // Delete a franchise by ID asynchronously.
        public async Task DeleteAsync(int id)
        {
            // Check if the franchise with the given ID exists.
            if (!await FranchiseExists(id))
            {
                // Throw an exception if the franchise is not found.
                throw new FranchiseNotFoundException(id);
            }

            // Find and remove the franchise from the database.
            var franchise = await _context.Franchises.FindAsync(id);
            _context.Franchises.Remove(franchise);
            await _context.SaveChangesAsync();
        }


        // Update movies associated with a franchise asynchronously.
        public async Task UpdateMoviesInFranchiseAsync(int franchiseId, IEnumerable<int> movieIds)
        {
            // Check if the franchise with the given ID exists.
            if (!await FranchiseExists(franchiseId))
            {
                // Throw an exception if the franchise is not found.
                throw new FranchiseNotFoundException(franchiseId);
            }

            // Retrieve the franchise with its associated movies from the database.
            var franchise = await _context.Franchises.Include(f => f.Movies).FirstOrDefaultAsync(f => f.Id == franchiseId);

            // Fetch movies associated with the given movieIds from the database.
            var associatedMoviesList = await _context.Movies
                .Where(m => movieIds.Contains(m.Id))
                .ToListAsync();

            // Clear the current associations and reset them.
            // franchise.Movies.Clear();

            // Add the fetched movies to the franchise's movie collection.
            foreach (var movie in associatedMoviesList)
            {
                franchise.Movies.Add(movie);
            }

            // Save changes to the database.
            await _context.SaveChangesAsync();
        }


        // Get all movies associated with a franchise asynchronously.
        public async Task<IEnumerable<Movie>> GetMoviesInFranchiseAsync(int franchiseId)
        {
            // Check if the franchise with the given ID exists.
            if (!await FranchiseExists(franchiseId))
            {
                // Throw an exception if the franchise is not found.
                throw new FranchiseNotFoundException(franchiseId);
            }

            // Retrieve the franchise with its associated movies from the database.
            var franchise = await _context.Franchises.Include(f => f.Movies)
                                                .ThenInclude(m => m.Characters)
                                                .FirstOrDefaultAsync(f => f.Id == franchiseId);

            // Return the list of movies associated with the franchise.
            return franchise?.Movies.ToList();
        }


        // Get all characters associated with all movies in a franchise asynchronously.
        public async Task<IEnumerable<Character>> GetCharactersInFranchiseAsync(int franchiseId)
        {
            // Check if the franchise with the given ID exists.
            if (!await FranchiseExists(franchiseId))
            {
                // Throw an exception if the franchise is not found.
                throw new FranchiseNotFoundException(franchiseId);
            }

            // Retrieve the franchise with its associated movies and characters from the database.
            var franchise = await _context.Franchises.Include(f => f.Movies)
                                                    .ThenInclude(m => m.Characters)
                                                    .FirstOrDefaultAsync(f => f.Id == franchiseId);

            // Return the list of characters associated with all movies in the franchise.
            return franchise.Movies.SelectMany(m => m.Characters).ToList();
        }


        // Check if a franchise with a given ID exists in the database.
        private async Task<bool> FranchiseExists(int id)
        {
            return await _context.Franchises.AnyAsync(e => e.Id == id);
        }
    }
}