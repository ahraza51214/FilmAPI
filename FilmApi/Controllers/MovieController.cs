using System;
using Microsoft.AspNetCore.Mvc;
using FilmApi.Data.Entities;
using FilmApi.Services;
using FilmApi.Exceptions;
using System.Net.Mime;
using AutoMapper;
using FilmApi.Data.DTOs.CharacterDTOs;
using FilmApi.Data.DTOs.MovieDTOs;

namespace FilmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class MovieController : ControllerBase
    {
        // Private field to store an instance of the ServiceFacade, providing access to movie-related services.
        private readonly ServiceFacade _serviceFacade;

        // Private field to store an instance of the auto mapper.
        private readonly IMapper _mapper;

        // Constructor for the MovieController, which takes a ServiceFacade as a dependency.
        public MovieController(ServiceFacade serviceFacade, IMapper mapper)
        {
            // Initialize the _serviceFacade field with the provided instance of ServiceFacade.
            _serviceFacade = serviceFacade;
            // Initialize the _mapper field with the provided instance of Imapper.
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves a list of all movies.
        /// </summary>
        /// <returns>A list containing all movies in the database.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMovies()
        {
            return Ok(_mapper.Map<List<MovieDTO>>(await _serviceFacade._movieService.GetAllAsync()));
        }

        /// <summary>
        /// Retrieves a specific movie by its ID.
        /// </summary>
        /// <param name="id">The ID of the movie to retrieve.</param>
        /// <returns>The movie with the specified ID.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDTO>> GetMovie(int id)
        {
            try
            {
                return _mapper.Map<MovieDTO>(await _serviceFacade._movieService.GetByIdAsync(id));
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
        public async Task<IActionResult> PutMovie(int id, MoviePutDTO movieDTO)
        {
            if (id != movieDTO.Id)
            {
                return BadRequest();
            }

            try
            {
                await _serviceFacade._movieService.UpdateAsync(_mapper.Map<Movie>(movieDTO));
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
        public async Task<ActionResult<MovieDTO>> PostMovie(MoviePostDTO MovieDTO)
        {
            var newMovie = await _serviceFacade._movieService.AddAsync(_mapper.Map<Movie>(MovieDTO));

            return CreatedAtAction("GetMovie", new { id = newMovie.Id }, _mapper.Map<MovieDTO>(newMovie));
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
        /// <param name="movieId">The unique ID of the movie to update.</param>
        /// <param name="movieCharacterDto">The data transfer object containing the list of character IDs to associate with the movie.</param>
        /// <returns>
        /// Returns a NoContent result if successful, NotFound with a error message if the movie doesn't exist, and BadRequest if the input is invalid.
        /// </returns>
        [HttpPut("{movieId}/characters")]
        public async Task<IActionResult> UpdateMovieCharacters(int movieId, [FromBody] MoviePutCharactersDTO movieCharacterDto)
        {
            // Validate the input DTO. Ensure it's not null and contains valid character IDs.
            if (movieCharacterDto == null || movieCharacterDto.CharacterIds == null || !movieCharacterDto.CharacterIds.Any())
            {
                // Return a BadRequest response if the input validation fails.
                return BadRequest("CharacterIds are required.");
            }

            try
            {
                // Call the service method to update the movie's associated characters.
                await _serviceFacade._movieService.UpdateCharactersInMovieAsync(movieId, movieCharacterDto.CharacterIds);

                // Return a NoContent (204) response if the update is successful.
                return NoContent();
            }
            catch (MovieNotFoundException ex)
            {
                // If the movie isn't found, return a NotFound (404) response with a error mesage.
                return NotFound(ex.Message);
            }
            
        }




        /// <summary>
        /// Get all the characters associated with a specific movie.
        /// </summary>
        /// <param name="movieId">Unique ID of the movie.</param>
        /// <returns>DTO encapsulating characters associated with the movie.</returns>
        [HttpGet("{movieId}/characters")]
        public async Task<ActionResult<MovieGetCharactersDTO>> GetCharactersInMovie(int movieId)
        {
            try
            {
                var movie = await _serviceFacade._movieService.GetCharactersInMovieAsync(movieId);

                // Map the domain object (Movie) to the DTO
                var movieCharacterDto = _mapper.Map<MovieGetCharactersDTO>(movie);

                return Ok(movieCharacterDto);
            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(ex.Message); // Return the error message if the movie is not found
            }
        }

    }
}