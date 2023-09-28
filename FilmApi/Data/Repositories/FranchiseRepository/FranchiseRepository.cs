using System;
using FilmApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmApi.Data.Repositories.FranchiseRepository
{
	public class FranchiseRepository : IFranchiseRepository
	{
        private readonly MovieDbContext _context;

		public FranchiseRepository(MovieDbContext context)
		{
            _context = context;
		}

        public async Task<IEnumerable<Franchise>> GetAllAsync()
        {
            return await _context.Franchises.ToListAsync();
        }

        public async Task<Franchise> GetByIdAsync(int id)
        {
            return await _context.Franchises.FindAsync(id);
        }

        public async Task AddAsync(Franchise franchise)
        {
            _context.Franchises.Add(franchise);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Franchise franchise)
        {
            _context.Franchises.Update(franchise);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var franchise = await _context.Franchises.FindAsync(id);
            if (franchise != null)
            {
                _context.Franchises.Remove(franchise);
                await _context.SaveChangesAsync();
            }
        }

        // Additional methods as needed
    }
}