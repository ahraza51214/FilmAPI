using System;
using AutoMapper;
using FilmApi.Data.DTOs.CharacterDTOs;
using FilmApi.Data.Entities;

namespace FilmApi.Mappers
{
    // Definition of the CharacterProfile class, which inherits from AutoMapper's Profile class
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            // CreateMap method to define mapping from Character to CharacterDTO
            CreateMap<Character, CharacterDTO>()
                .ForMember(cdto => cdto.Movies, options => options
                    // Map the 'Movies' property from 'Character' to 'CharacterDTO'
                    .MapFrom(c => c.Movies.Select(m => new CharacterMovieDTO
                    {
                        // Map the 'Id' property from 'Movie' to 'MovieId' in 'CharacterMovieDTO'
                        MovieId = m.Id,
                        // Map the 'Title' property from 'Movie' to 'MovieTitles' in 'CharacterMovieDTO'
                        MovieTitle = m.Title
                    })));

            // CreateMap method to define bidirectional mapping between Character and CharacterPostDTO
            CreateMap<Character, CharacterPostDTO>().ReverseMap();

            // CreateMap method to define bidirectional mapping between Character and CharacterPutDTO
            CreateMap<Character, CharacterPutDTO>().ReverseMap();
        }
    }
}