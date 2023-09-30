using System;
using FilmApi.Services.CharacterService;
using FilmApi.Services.FranchiseService;
using FilmApi.Services.MovieService;

namespace FilmApi.Services
{
    // ServiceFacade acts as a facade to provide a unified interface to access various services.
    public class ServiceFacade
    {
        // Service for character-related methods.
        public readonly ICharacterService _characterService;

        // Service for franchise-related methods.
        public readonly IFranchiseService _franchiseService;

        // Service for movie-related methods.
        public readonly IMovieService _movieService;

        // Constructor to initialize the ServiceFacade with instances of character, franchise, and movie services.
        public ServiceFacade(ICharacterService characterService, IFranchiseService franchiseService, IMovieService movieService)
        {
            _characterService = characterService;
            _franchiseService = franchiseService;
            _movieService = movieService;
        }
    }
}