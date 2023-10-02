using System;
using AutoMapper;
using FilmApi.Data.DTOs.FranchiseDTOs;
using FilmApi.Data.DTOs.MovieDTOs;
using FilmApi.Data.Entities;

namespace FilmApi.Mappers
{
    // Definition of the MovieProfile class, which inherits from AutoMapper's Profile class
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            // CreateMap method to define mapping from Movie and MovieDTO
            CreateMap<Movie, MovieDTO>()
                .ForMember(mdto => mdto.Characters, options => options
                    // Map the 'Characters' property from 'Movie' to 'MovieDTO'
                    .MapFrom(m => m.Characters.Select(c => new MovieCharacterDTO
                    {
                        // Map the 'Id' property from 'Movie' to 'CharacterId' in 'MovieCharacterDTO'
                        CharacterId = c.Id,
                        // Map the 'FullName' property from 'Movie' to 'CharacterFullName' in 'MovieCharacterDTO'
                        CharacterFullName = c.FullName
                    })));

            // CreateMap method to define bidirectional mapping between Movie and MoviePutDTO
            CreateMap<Movie, MoviePutDTO>().ReverseMap();

            // CreateMap method to define bidirectional mapping between Movie and MoviePostDTO
            CreateMap<Movie, MoviePostDTO>().ReverseMap();
        }
    }
}