using System;
using Microsoft.AspNetCore.Mvc;
using FilmApi.Data.Entities;
using FilmApi.Services;
using FilmApi.Exceptions;

namespace FilmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {

        private readonly ServiceFacade _serviceFacade;

        public CharacterController(ServiceFacade serviceFacade)
        {
            _serviceFacade = serviceFacade;
        }


        // GET: api/Character
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
        {
            return Ok(await _serviceFacade._characterService.GetAllAsync());
        }


        // GET: api/Character/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
            try
            {
                return await _serviceFacade._characterService.GetByIdAsync(id);
            }
            catch (CharacterNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        // PUT: api/Character/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, Character character)
        {
            if (id != character.Id)
            {
                return BadRequest();
            }

            try
            {
                await _serviceFacade._characterService.UpdateAsync(character);
            }
            catch (CharacterNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }


        // POST: api/Character
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(Character character)
        {
            await _serviceFacade._characterService.AddAsync(character);

            return CreatedAtAction("GetCharacter", new { id = character.Id }, character);
        }


        // DELETE: api/Character/5
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