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

        private async Task<bool> FranchiseExists(int id)
        {
            return await _context.Franchises.AnyAsync(e => e.Id == id);
        }
    }
}

