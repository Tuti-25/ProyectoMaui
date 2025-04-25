using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectoMauiAPI.Data;
using ProjectoMauiAPI.Models.Entities;

namespace ProjectoMauiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeverityController : ControllerBase
    {
        private readonly DemoDbContext _demoDbContext;

        public SeverityController(DemoDbContext context)
        {
            _demoDbContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Severidad>>> GetSeveridades()
        {
            return await _demoDbContext.Set<Severidad>().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Severidad>> GetSeveridad(int id)
        {
            var severidad = await _demoDbContext.Set<Severidad>().FindAsync(id);

            if (severidad == null)
            {
                return NotFound();
            }

            return severidad;
        }

        [HttpPost]
        public async Task<ActionResult<Severidad>> PostSeveridad(Severidad severidad)
        {
            _demoDbContext.Set<Severidad>().Add(severidad);
            await _demoDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSeveridad), new { id = severidad.IdSeveridad }, severidad);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeveridad(int id, Severidad severidad)
        {
            if (id != severidad.IdSeveridad)
            {
                return BadRequest();
            }

            _demoDbContext.Entry(severidad).State = EntityState.Modified;

            try
            {
                await _demoDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeveridadExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeveridad(int id)
        {
            var severidad = await _demoDbContext.Set<Severidad>().FindAsync(id);
            if (severidad == null)
            {
                return NotFound();
            }

            _demoDbContext.Set<Severidad>().Remove(severidad);
            await _demoDbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool SeveridadExists(int id)
        {
            return _demoDbContext.Set<Severidad>().Any(e => e.IdSeveridad == id);
        }
    }
}
