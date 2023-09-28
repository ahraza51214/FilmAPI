using System;
using FilmApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmApi.Data.Repositories.CharacterRepository
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly MovieDbContext _context;

        public CharacterRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Character>> GetAllAsync()
        {
            return await _context.Characters.ToListAsync();
        }

        public async Task<Character> GetByIdAsync(int id)
        {
            return await _context.Characters.FindAsync(id);
        }

        public async Task AddAsync(Character character)
        {
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Character character)
        {
            _context.Characters.Update(character);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character != null)
            {
                _context.Characters.Remove(character);
                await _context.SaveChangesAsync();
            }
        }

        // Additional methods as needed
    }

}