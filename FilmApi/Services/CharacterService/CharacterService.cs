using System;
using FilmApi.Data;
using FilmApi.Data.Entities;
using FilmApi.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace FilmApi.Services.CharacterService
{
    // Implementation of the ICharacterService interface for character-related methods.
    public class CharacterService : ICharacterService
    {
        // Database context for character-related methods.
        private readonly MovieDbContext _context;

        // Constructor to initialize the CharacterService with a MovieDbContext.
        public CharacterService(MovieDbContext context)
        {
            _context = context;
        }

        // Get all characters asynchronously.
        public async Task<IEnumerable<Character>> GetAllAsync()
        {
            return await _context.Characters.ToListAsync();
        }

        // Get a character by its ID asynchronously.
        public async Task<Character?> GetByIdAsync(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character is null)
            {
                // Throw an exception if the character with the specified ID is not found.
                throw new CharacterNotFoundException(id);
            }
            return character;
        }

        // Update a character asynchronously.
        public async Task<Character> UpdateAsync(Character obj)
        {
            // Check if the character with the given ID exists.
            if (!await CharacterExists(obj.Id))
            {
                // Throw an exception if the character is not found.
                throw new CharacterNotFoundException(obj.Id);
            }

            // Mark the character entity as modified and save changes to the database.
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();

            return obj;
        }

        // Add a new character asynchronously.
        public async Task<Character> AddAsync(Character obj)
        {
            // Add the character to the database and save changes.
            await _context.Characters.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        // Delete a character by ID asynchronously.
        public async Task DeleteAsync(int id)
        {
            // Check if the character with the given ID exists.
            if (!await CharacterExists(id))
            {
                // Throw an exception if the character is not found.
                throw new CharacterNotFoundException(id);
            }

            // Find and remove the character from the database.
            var character = await _context.Characters.FindAsync(id);
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
        }

        // Check if a character with a given ID exists in the database.
        private async Task<bool> CharacterExists(int id)
        {
            return await _context.Characters.AnyAsync(e => e.Id == id);
        }
    }
}
