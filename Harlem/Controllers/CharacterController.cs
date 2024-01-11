using APIService.Context.Persistence;
using APIService.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Character> characters = _context.Characters.Include(x => x.Backpack)
                                                                   .Include(x => x.Weapons)
                                                                   .ToList();

            if (!characters.Any()) { return NoContent(); }

            return Ok(characters);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            Character? character = await _context.Characters.Include(c => c.Backpack)
                                                            .Include(c => c.Weapons)
                                                            .FirstOrDefaultAsync(c => c.Id == id);

            if (character is null) { return NotFound(); }

            return Ok(character);
        }
    }
}
