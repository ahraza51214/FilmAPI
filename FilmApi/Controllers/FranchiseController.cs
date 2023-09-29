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

        // GET: api/Franchise
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Franchise>>> GetFranchises()
        {
            return Ok(await _serviceFacade._franchiseService.GetAllAsync());
        }

        // GET: api/Franchise/5
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

        // PUT: api/Franchise/5
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

        // POST: api/Franchise
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Franchise>> PostFranchise(Franchise franchise)
        {
            await _serviceFacade._franchiseService.AddAsync(franchise);

            return CreatedAtAction("GetFranchise", new { id = franchise.Id }, franchise);
        }

        // DELETE: api/Franchise/5
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
    }
}
