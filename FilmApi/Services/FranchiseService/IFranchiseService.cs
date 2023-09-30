using System;
using FilmApi.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FilmApi.Services.FranchiseService
{
	public interface IFranchiseService : ICrudService<Franchise, int>
	{
        Task<IEnumerable<Movie>> GetMoviesInFranchiseAsync(int franchiseId);

    }
}

