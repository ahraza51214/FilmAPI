using System;
using FilmApi.Services.CharacterService;
using FilmApi.Services.FranchiseService;
using FilmApi.Services.MovieService;

namespace FilmApi.Services
{
	public class ServiceFacade
	{
		public readonly ICharacterService _characterService;
		public readonly IFranchiseService _franchiseService;
		public readonly IMovieService _movieService;

		public ServiceFacade(ICharacterService characterService, IFranchiseService franchiseService, IMovieService movieService)
		{
			_characterService = characterService;
			_franchiseService = franchiseService;
			_movieService = movieService;
		}
	}
}