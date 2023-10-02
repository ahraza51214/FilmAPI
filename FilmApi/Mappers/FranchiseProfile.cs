using System;
using AutoMapper;
using FilmApi.Data.DTOs.CharacterDTOs;
using FilmApi.Data.DTOs.FranchiseDTOs;
using FilmApi.Data.Entities;

namespace FilmApi.Mappers
{
    // Definition of the FranchiseProfile class, which inherits from AutoMapper's Profile class
    public class FranchiseProfile : Profile
	{
        public FranchiseProfile()
        {
            // CreateMap method to define mapping from Franchise and FranchiseDTO
            CreateMap<Franchise, FranchiseDTO>()
                .ForMember(fdto => fdto.Movies, options => options
                    // Map the 'Movies' property from 'Franchise' to 'FranchiseDTO'
                    .MapFrom(f => f.Movies.Select(m => new FranchiseMovieDTO
                    {
                        // Map the 'Id' property from 'Movie' to 'MovieId' in 'FranchiseMoviesDTO'
                        MovieId = m.Id,
                        // Map the 'Title' property from 'Movie' to 'MovieTitles' in 'FranchiseMoviesDTO'
                        MovieTitle = m.Title
                    })));

            // CreateMap method to define bidirectional mapping between Franchise and FranchisePostDTO
            CreateMap<Franchise, FranchisePostDTO>().ReverseMap();

            // CreateMap method to define bidirectional mapping between Franchise and FranchisePutDTO
            CreateMap<Franchise, FranchisePutDTO>().ReverseMap();
        }
    }
}