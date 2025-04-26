using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectoMauiAPI.Data;
using ProjectoMauiAPI.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectoMauiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly DemoDbContext _demoDbContext;

        public AgentController(DemoDbContext demoDbContext)
        {
            _demoDbContext = demoDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agente>>> GetAgentes()
        {
            return await _demoDbContext.Agentes.Include(a => a.Rol).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Agente>> GetAgente(int id)
        {
            var agente = await _demoDbContext.Agentes.Include(a => a.Rol)
                                               .FirstOrDefaultAsync(a => a.IdAgente == id);

            if (agente == null)
            {
                return NotFound();
            }

            return agente;
        }

        [HttpGet("validate/{id}/{cedula}")]
        public async Task<ActionResult<Agente>> GetAgenteByIdYCedula(int id, string cedula)
        {
            var agente = await _demoDbContext.Agentes
                .FirstOrDefaultAsync(a => a.IdAgente == id && a.CedulaAgente == cedula);

            if (agente == null)
            {
                return NotFound("No se encontro un agente con el ID y la cedula que ingresaste");
            }

            return Ok(agente);
        }

        [HttpPost]
        public async Task<ActionResult<Agente>> PostAgente(Agente agente)
        {
            _demoDbContext.Agentes.Add(agente);
            await _demoDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAgente), new { id = agente.IdAgente }, agente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgente(int id, Agente agente)
        {
            if (id != agente.IdAgente)
            {
                return BadRequest("ID del agente no coincide");
            }

            _demoDbContext.Entry(agente).State = EntityState.Modified;

            try
            {
                await _demoDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgenteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgente(int id)
        {
            var agente = await _demoDbContext.Agentes.FindAsync(id);
            if (agente == null)
            {
                return NotFound();
            }

            _demoDbContext.Agentes.Remove(agente);
            await _demoDbContext.SaveChangesAsync();

            return Ok();
        }

        private bool AgenteExists(int id)
        {
            return _demoDbContext.Agentes.Any(e => e.IdAgente == id);
        }
    }
}
