using System;
using AutoMapper;
using FilmApi.Data.DTOs.MovieDTOs;
using FilmApi.Data.Entities;

namespace FilmApi.Mappers
{
    // Definition of the MovieProfile class, which inherits from AutoMapper's Profile class
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            // CreateMap method to define bidirectional mapping between Movie and MovieDTO
            CreateMap<Movie, MovieDTO>().ReverseMap();

            // CreateMap method to define bidirectional mapping between Movie and MoviePutDTO
            CreateMap<Movie, MoviePutDTO>().ReverseMap();

            // CreateMap method to define bidirectional mapping between Movie and MoviePostDTO
            CreateMap<Movie, MoviePostDTO>().ReverseMap();
        }
    }
}