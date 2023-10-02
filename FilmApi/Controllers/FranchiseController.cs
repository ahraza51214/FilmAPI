using System;
using Microsoft.AspNetCore.Mvc;
using FilmApi.Data.Entities;
using FilmApi.Services;
using FilmApi.Exceptions;
using System.Net.Mime;
using AutoMapper;
using FilmApi.Data.DTOs.FranchiseDTOs;
using FilmApi.Data.DTOs.MovieDTOs;
using FilmApi.Data.DTOs.CharacterDTOs;

namespace FilmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class FranchiseController : ControllerBase
    {
        // Private field to store an instance of the ServiceFacade, providing access to franchise-related services.
        private readonly ServiceFacade _serviceFacade;

        // Private field to store an instance of the auto mapper.
        private readonly IMapper _mapper;

        // Constructor for the FranchiseController, which takes a ServiceFacade as a dependency.
        public FranchiseController(ServiceFacade serviceFacade, IMapper mapper)
        {
            // Initialize the _serviceFacade field with the provided instance of ServiceFacade.
            _serviceFacade = serviceFacade;
            // Initialize the _mapper field with the provided instance of Imapper.
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all franchises.
        /// </summary>
        /// <returns>A list of all franchises.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FranchiseDTO>>> GetFranchises()
        {
            return Ok(_mapper.Map<List<FranchiseDTO>>(await _serviceFacade._franchiseService.GetAllAsync()));
        }

        /// <summary>
        /// Retrieves a specific franchise by ID.
        /// </summary>
        /// <param name="id">The ID of the franchise to retrieve.</param>
        /// <returns>The franchise with the specified ID if found; otherwise, an error message.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<FranchiseDTO>> GetFranchise(int id)
        {
            try
            {
                return _mapper.Map<FranchiseDTO>(await _serviceFacade._franchiseService.GetByIdAsync(id));
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Updates a specific franchise's details.
        /// </summary>
        /// <param name="id">The ID of the franchise to update.</param>
        /// <param name="franchiseDTO">The updated details of the franchise.</param>
        /// <returns>An IActionResult indicating the result of the operation.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, FranchisePutDTO franchiseDTO)
        {
            if (id != franchiseDTO.Id)
            {
                return BadRequest();
            }

            try
            {
                await _serviceFacade._franchiseService.UpdateAsync(_mapper.Map<Franchise>(franchiseDTO));
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        /// <summary>
        /// Adds a new franchise to the database.
        /// </summary>
        /// <param name="franchiseDTO">The details of the new franchise to add.</param>
        /// <returns>The newly created franchise.</returns>
        [HttpPost]
        public async Task<ActionResult<FranchiseDTO>> PostFranchise(FranchisePostDTO franchiseDTO)
        {
            var newFranchise = await _serviceFacade._franchiseService.AddAsync(_mapper.Map<Franchise>(franchiseDTO));

            return CreatedAtAction("GetFranchise", new { id = newFranchise.Id }, _mapper.Map<FranchiseDTO>(newFranchise));
        }

        /// <summary>
        /// Deletes a specific franchise by ID.
        /// </summary>
        /// <param name="id">The ID of the franchise to delete.</param>
        /// <returns>An IActionResult indicating the result of the operation.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
            try
            {
                await _serviceFacade._franchiseService.DeleteAsync(id);
                return NoContent();
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Updates the movies associated with a given franchise.
        /// </summary>
        /// <param name="franchiseId">The ID of the franchise to update.</param>
        /// <param name="movieIds">The list of movie IDs to associate with the franchise.</param>
        /// <returns>Returns a No Content response if the update was successful, or Not Found if the franchise was not found.</returns>
        [HttpPut("{franchiseId}/movies")]
        public async Task<IActionResult> UpdateMoviesInFranchise(int franchiseId, [FromBody] List<int> movieIds)
        {
            try
            {
                await _serviceFacade._franchiseService.UpdateMoviesInFranchiseAsync(franchiseId, movieIds);
                return NoContent(); // HTTP 204 No Content response for a successful operation with no additional output.
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(ex.Message); // Returns a 404 Not Found response with a detailed error message.
            }
        }

        /// <summary>
        /// Fetches all the movies associated with a specific franchise.
        /// </summary>
        /// <param name="franchiseId">The ID of the franchise.</param>
        /// <returns>A list of movies associated with the given franchise.</returns>
        [HttpGet("{franchiseId}/movies")]
        public async Task<ActionResult<IEnumerable<MovieDTO>>>GetMoviesInFranchise(int franchiseId)
        {
            try
            {
                return Ok(_mapper
                    .Map<IEnumerable<MovieDTO>>(await _serviceFacade._franchiseService
                    .GetMoviesInFranchiseAsync(franchiseId)));
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves a list of characters associated with a given franchise.
        /// </summary>
        /// <param name="franchiseId">The ID of the franchise for which to retrieve associated characters.</param>
        /// <returns>Returns a list of characters associated with the specified franchise or a Not Found response if the franchise was not found.</returns>
        [HttpGet("{franchiseId}/characters")]
        public async Task<ActionResult<IEnumerable<CharacterDTO>>> GetCharactersInFranchise(int franchiseId)
        {
            try
            {
                return Ok(_mapper
                    .Map<IEnumerable<CharacterDTO>>(await _serviceFacade._franchiseService
                    .GetCharactersInFranchiseAsync(franchiseId)));
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}