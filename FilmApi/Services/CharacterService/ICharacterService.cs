using System;
using FilmApi.Data.Entities;

namespace FilmApi.Services.CharacterService
{
	internal interface ICharacterService : ICrudService<Character, int>
	{
	}
}