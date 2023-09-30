using System;
using Microsoft.AspNetCore.Mvc;
using FilmApi.Data.Entities;
using FilmApi.Services;
using FilmApi.Exceptions;

namespace FilmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FranchiseController : ControllerBase
    {
        private readonly ServiceFacade _serviceFacade;

        public FranchiseController(ServiceFacade serviceFacade)
        {
            _serviceFacade = serviceFacade;
        }

        /// <summary>
        /// Retrieves all franchises.
        /// </summary>
        /// <returns>A list of all franchises.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Franchise>>> GetFranchises()
        {
            return Ok(await _serviceFacade._franchiseService.GetAllAsync());
        }

        /// <summary>
        /// Retrieves a specific franchise by ID.
        /// </summary>
        /// <param name="id">The ID of the franchise to retrieve.</param>
        /// <returns>The franchise with the specified ID if found; otherwise, an error message.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Franchise>> GetFranchise(int id)
        {
            try
            {
                return await _serviceFacade._franchiseService.GetByIdAsync(id);
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
        /// <param name="franchise">The updated details of the franchise.</param>
        /// <returns>An IActionResult indicating the result of the operation.</returns>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, Franchise franchise)
        {
            if (id != franchise.Id)
            {
                return BadRequest();
            }

            try
            {
                await _serviceFacade._franchiseService.UpdateAsync(franchise);
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
        /// <param name="franchise">The details of the new franchise to add.</param>
        /// <returns>The newly created franchise.</returns>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Franchise>> PostFranchise(Franchise franchise)
        {
            await _serviceFacade._franchiseService.AddAsync(franchise);

            return CreatedAtAction("GetFranchise", new { id = franchise.Id }, franchise);
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
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesInFranchise(int franchiseId)
        {
            var movies = await _serviceFacade._franchiseService.GetMoviesInFranchiseAsync(franchiseId);

            if (movies == null || !movies.Any())
            {
                return NotFound($"No movies found for franchise with ID {franchiseId}.");
            }

            return Ok(movies);
        }

        /// <summary>
        /// Retrieves a list of characters associated with a given franchise.
        /// </summary>
        /// <param name="franchiseId">The ID of the franchise for which to retrieve associated characters.</param>
        /// <returns>Returns a list of characters associated with the specified franchise or a Not Found response if the franchise was not found.</returns>
        [HttpGet("{franchiseId}/characters")]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharactersInFranchise(int franchiseId)
        {
            try
            {
                var characters = await _serviceFacade._franchiseService.GetCharactersInFranchiseAsync(franchiseId);
                return Ok(characters);
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(ex.Message); // Returns a 404 Not Found response with a detailed error message.
            }
            
        }

    }
}
