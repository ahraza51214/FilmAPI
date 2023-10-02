using System;
using AutoMapper;
using FilmApi.Data.DTOs.CharacterDTOs;
using FilmApi.Data.Entities;

namespace FilmApi.Mappers
{
	public class CharacterProfile : Profile
	{
		public CharacterProfile()
		{
			CreateMap<Character, CharacterDTO>().ReverseMap();
            CreateMap<Character, CharacterPostDTO>().ReverseMap();
			CreateMap<Character, CharacterPutDTO>().ReverseMap();
		}
	}
}