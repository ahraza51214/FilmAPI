using System;
using FilmApi.Data.Entities;

namespace FilmApi.Services.CharacterService
{
    // Interface for Character-related methods that extends the ICrudService interface.
    public interface ICharacterService : ICrudService<Character, int>
	{
	}
}