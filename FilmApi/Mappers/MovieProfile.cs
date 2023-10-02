using System;
using AutoMapper;
using FilmApi.Data.DTOs.MovieDTOs;
using FilmApi.Data.Entities;
using Humanizer;

namespace FilmApi.Mappers
{
	public class MovieProfile : Profile
	{
        // AutoMapper profile for setting up mappings related to movies.

        public MovieProfile()
		{
            CreateMap<Movie, MovieDTO>().ReverseMap();              // Map Movie to MovieDTO and vice versa
            CreateMap<Movie, MoviePostDTO>().ReverseMap();          // Map Movie to MoviePostDTO and vice versa
            CreateMap<Movie, MoviePutDTO>().ReverseMap();           // Map Movie to MoviePutDTO and vice versa
			CreateMap<Movie, MoviePutCharactersDTO>().ReverseMap(); // Map Movie to MoviePutCharactersDTO and vice versa
			CreateMap<Movie, MovieGetCharactersDTO>().ReverseMap(); // Map Movie to MovieGetCharactersDTO and vice versa
        }
	}
}