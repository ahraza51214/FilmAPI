using System;
using AutoMapper;
using FilmApi.Data.DTOs.FranchiseDTOs;
using FilmApi.Data.Entities;

namespace FilmApi.Mappers
{
    // Definition of the FranchiseProfile class, which inherits from AutoMapper's Profile class
    public class FranchiseProfile : Profile
	{
        public FranchiseProfile()
        {
            // CreateMap method to define bidirectional mapping between Franchise and FranchiseDTO
            CreateMap<Franchise, FranchiseDTO>().ReverseMap();

            // CreateMap method to define bidirectional mapping between Franchise and FranchisePostDTO
            CreateMap<Franchise, FranchisePostDTO>().ReverseMap();

            // CreateMap method to define bidirectional mapping between Franchise and FranchisePutDTO
            CreateMap<Franchise, FranchisePutDTO>().ReverseMap();
        }
    }
}