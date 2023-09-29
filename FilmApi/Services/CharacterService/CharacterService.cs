using System;
using FilmApi.Data;
using FilmApi.Data.Entities;
using FilmApi.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace FilmApi.Services.CharacterService
{
	public class CharacterService : ICharacterService
	{
        private readonly MovieDbContext _context;

        public CharacterService(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Character>> GetAllAsync()
        {
            return await _context.Characters.ToListAsync();
        }

        public async Task<Character?> GetByIdAsync(int id)
        {
            return await _context.Characters.FindAsync(id);
        }

        public async Task<Character> UpdateAsync(Character obj)
        {
            if (!await CharacterExists(obj.Id))
            {
                throw new CharacterNotFoundException(obj.Id);
            }

            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();

            return obj;
        }

        public async Task<Character> AddAsync(Character obj)
        {
            await _context.Characters.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task DeleteAsync(int id)
        {
            // Early exit if prof doesnt exist
            if (!await CharacterExists(id))
            {
                throw new CharacterNotFoundException(id);
            }

            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                throw new CharacterNotFoundException(id);
            }
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
        }

        private async Task<bool> CharacterExists(int id)
        {
            return await _context.Characters.AnyAsync(e => e.Id == id);
        }
    }
}