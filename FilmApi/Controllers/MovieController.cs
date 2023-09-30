using System;
using Microsoft.AspNetCore.Mvc;
using FilmApi.Data.Entities;
using FilmApi.Services;
using FilmApi.Exceptions;

namespace FilmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ServiceFacade _serviceFacade;

        public MovieController(ServiceFacade serviceFacade)
        {
            _serviceFacade = serviceFacade;
        }

        /// <summary>
        /// Retrieves a list of all movies.
        /// </summary>
        /// <returns>A list containing all movies in the database.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            return Ok(await _serviceFacade._movieService.GetAllAsync());
        }

        /// <summary>
        /// Retrieves a specific movie by its ID.
        /// </summary>
        /// <param name="id">The ID of the movie to retrieve.</param>
        /// <returns>The movie with the specified ID.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            try
            {
                return await _serviceFacade._movieService.GetByIdAsync(id);
            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Updates the details of a specific movie.
        /// </summary>
        /// <param name="id">The ID of the movie to update.</param>
        /// <param name="movie">The updated movie details.</param>
        /// <returns>An IActionResult indicating the result of the update operation.</returns>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            try
            {
                await _serviceFacade._movieService.UpdateAsync(movie);
            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        /// <summary>
        /// Adds a new movie to the database.
        /// </summary>
        /// <param name="movie">The details of the new movie to add.</param>
        /// <returns>The newly created movie.</returns>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            await _serviceFacade._movieService.AddAsync(movie);

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        /// <summary>
        /// Deletes a specific movie from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the movie to delete.</param>
        /// <returns>An IActionResult indicating the result of the delete operation.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            try
            {
                await _serviceFacade._movieService.DeleteAsync(id);
                return NoContent();
            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }



        /// <summary>
        /// Updates the list of characters associated with a specific movie.
        /// </summary>
        /// <param name="movieId">The unique identifier of the movie.</param>
        /// <param name="characterIds">A list of character IDs to be associated with the movie.</param>
        /// <returns>
        /// Returns a NoContent (204) status code if the update is successful.
        /// Returns a NotFound (404) status if the specified movie is not found.
        /// </returns>
        [HttpPut("{movieId}/characters")]
        public async Task<IActionResult> UpdateMovieCharacters(int movieId, [FromBody] List<int> characterIds)
        {
            try
            {
                await _serviceFacade._movieService.UpdateCharactersInMovieAsync(movieId, characterIds);
                return NoContent(); // You can return NoContent (204) for successful updates without a body. Alternatively, return Ok() if you want.
            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            
        }
    }
}