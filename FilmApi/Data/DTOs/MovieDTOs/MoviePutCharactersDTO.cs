using FilmApi.Data.Entities;
using System;
namespace FilmApi.Data.DTOs.MovieDTOs
{
	public class MoviePutCharactersDTO
	{
        //public int Id { get; set; }
        public List<int> CharacterIds { get; set; }

    }
}