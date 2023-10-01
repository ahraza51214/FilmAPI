using System;
using Microsoft.AspNetCore.Mvc;
using FilmApi.Data.Entities;
using FilmApi.Services;
using FilmApi.Exceptions;
using System.Net.Mime;
using AutoMapper;
using FilmApi.Data.DTOs.CharacterDTOs;

namespace FilmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class CharacterController : ControllerBase
    {

        // Private field to store an instance of the ServiceFacade, providing access to character-related services.
        private readonly ServiceFacade _serviceFacade;

        // Private field to store an instance of the auto mapper.
        private readonly IMapper _mapper;

        // Constructor for the CharacterController, which takes a ServiceFacade as a dependency.
        public CharacterController(ServiceFacade serviceFacade, IMapper mapper)
        {
            // Initialize the serviceFacade field with the provided instance of ServiceFacade.
            _serviceFacade = serviceFacade;
            // Initialize the _mapper field with the provided instance of Imapper.
            _mapper = mapper;
        }

        /// <summary>
        /// Get all Characters
        /// </summary>
        /// <returns>A list of characters.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterDTO>>> GetCharacters()
        {
            return Ok(_mapper.Map<List<CharacterDTO>>(await _serviceFacade._characterService.GetAllAsync()));
        }

        /// <summary>
        /// Retrieves a specific Character by its unique ID.
        /// </summary>
        /// <param name="id">The unique ID of the character.</param>
        /// <returns>A Character object if found; otherwise, an error message.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterDTO>> GetCharacter(int id)
        {
            try
            {
                return _mapper.Map<CharacterDTO>(await _serviceFacade._characterService.GetByIdAsync(id));
            }
            catch (CharacterNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Updates the details of a specific Character based on the provided character object and unique ID.
        /// </summary>
        /// <param name="id">The unique ID of the character to be updated.</param>
        /// <param name="characterDTO">The character object containing the updated details.</param>
        /// <returns>Returns NoContent if the operation is successful; otherwise, BadRequest or NotFound based on the error.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, CharacterPutDTO characterDTO)
        {
            if (id != characterDTO.Id)
            {
                return BadRequest();
            }

            try
            {
                await _serviceFacade._characterService.UpdateAsync(_mapper.Map<Character>(characterDTO));
            }
            catch (CharacterNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        /// <summary>
        /// Adds a new Character to the database.
        /// </summary>
        /// <param name="characterDTO">The character object to be added.</param>
        /// <returns>Returns a CreatedAtAction result, directing to the GetCharacter action to retrieve the newly added character; otherwise, an error response.</returns>
        [HttpPost]
        public async Task<ActionResult<CharacterDTO>> PostCharacter(CharacterPostDTO characterDTO)
        {
            var newCharacter = await _serviceFacade._characterService.AddAsync(_mapper.Map<Character>(characterDTO));

            return CreatedAtAction("GetCharacter", new { id = newCharacter.Id }, _mapper.Map<CharacterDTO>(newCharacter));
        }

        /// <summary>
        /// Deletes a specified Character from the database.
        /// </summary>
        /// <param name="id">The unique ID of the character to be deleted.</param>
        /// <returns>Returns a NoContent response if deletion is successful; otherwise, a NotFound response with an error message.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            try
            {
                //await _profService.DeleteAsync(id);
                await _serviceFacade._characterService.DeleteAsync(id);
                return NoContent();
            }
            catch (CharacterNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}