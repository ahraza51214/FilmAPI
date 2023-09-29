using System;
using FilmApi.Services.CharacterService;
using FilmApi.Services.FranchiseService;
using FilmApi.Services.MovieService;

namespace FilmApi.Services
{
	public class ServiceFacade
	{
		internal readonly ICharacterService _characterService;
		internal readonly IFranchiseService _franchiseService;
		internal readonly IMovieService _movieService;

		internal ServiceFacade(ICharacterService characterService, IFranchiseService franchiseService, IMovieService movieService)
		{
			_characterService = characterService;
			_franchiseService = franchiseService;
			_movieService = movieService;
		}
	}
}