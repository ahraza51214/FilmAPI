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
                    .MapFrom(c => c.Movies.Select(m => m.Id))) // Mapping Movies property to an array of movie IDs
                .ForMember(cdto => cdto.MovieTitles, options => options
                    .MapFrom(c => c.Movies.Select(m => m.Title))); // Mapping MovieTitles property to an array of movie titles

            // CreateMap method to define bidirectional mapping between Character and CharacterPostDTO
            CreateMap<Character, CharacterPostDTO>().ReverseMap();

            // CreateMap method to define bidirectional mapping between Character and CharacterPutDTO
            CreateMap<Character, CharacterPutDTO>().ReverseMap();
        }
    }
}