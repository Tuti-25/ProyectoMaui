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
    public class RoleController1 : ControllerBase
    {
        private readonly DemoDbContext _demoDbContext;

        public RoleController1(DemoDbContext demoDbContext)
        {
            _demoDbContext = demoDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rol>>> GetRoles()
        {
            var roles = await _demoDbContext.Roles.ToListAsync();
            if (roles == null || roles.Count == 0)
            {
                return NotFound("No se encontraron roles");
            }

            return Ok(roles);
        }
    }
}
