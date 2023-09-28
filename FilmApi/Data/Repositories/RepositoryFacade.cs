using System;
using FilmApi.Data.Repositories.CharacterRepository;
using FilmApi.Data.Repositories.FranchiseRepository;
using FilmApi.Data.Repositories.MovieRepository;

namespace FilmApi.Data.Repositories
{
	public class RepositoryFacade
	{
        public readonly IMovieRepository _movieRepository;
        public readonly ICharacterRepository _characterRepository;
        public readonly IFranchiseRepository _franchiseRepository;

        public RepositoryFacade(
            IMovieRepository movieRepository,
            ICharacterRepository characterRepository,
            IFranchiseRepository franchiseRepository)
        {
            _movieRepository = movieRepository;
            _characterRepository = characterRepository;
            _franchiseRepository = franchiseRepository;
        }
    }
}