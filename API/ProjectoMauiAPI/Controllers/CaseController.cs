using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectoMauiAPI.Data;
using ProjectoMauiAPI.Models.Entities;

namespace ProjectoMauiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseController : ControllerBase
    {
        private readonly DemoDbContext _context;

        public CaseController(DemoDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> CrearCaso([FromBody] Caso caso)
        {
            if (caso == null)
                return BadRequest("El caso no puede ser nulo");

            caso.FechaCreacion = DateTime.UtcNow;

            _context.Casos.Add(caso);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObtenerCaso), new { id = caso.IdCaso }, caso);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerCaso(int id)
        {
            var caso = await _context.Casos.FindAsync(id);
            if (caso == null)
                return NotFound();

            return Ok(caso);
        }
    }
}
