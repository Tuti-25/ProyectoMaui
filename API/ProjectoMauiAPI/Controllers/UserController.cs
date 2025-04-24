using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectoMauiAPI.Data;
using ProjectoMauiAPI.Models.Entities;

namespace ProjectoMauiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DemoDbContext _demoDbContext;
        public UserController(DemoDbContext demoDbContext)
        {
            _demoDbContext = demoDbContext;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            return _demoDbContext.Usuarios;
        }


        [HttpGet("{IdUsuario}")]
        public async Task<ActionResult<Usuario?>> GetById(int IdUsuario)
        {
            return await _demoDbContext.Usuarios.Where(x => x.IdUsuario == IdUsuario).SingleOrDefaultAsync();

        }

        [HttpPost]
        public async Task<ActionResult> Create(Usuario usuario)
        {
           await  _demoDbContext.Usuarios.AddAsync(usuario);
           await _demoDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new {idusuario = usuario.IdUsuario}, usuario);
        }

        [HttpPut] 
        public async Task<ActionResult> Update(Usuario usuario)
        {
            _demoDbContext.Usuarios.Update(usuario);
            await _demoDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{IdUsuario}")]
        public async Task<ActionResult> Delete(int IdUsuario)
        {
            var usuarioGetByIdResult = await GetById(IdUsuario);

            if (usuarioGetByIdResult.Value is null)
            {
                return NotFound();
            }
             
            _demoDbContext.Remove(usuarioGetByIdResult.Value);
            await _demoDbContext.SaveChangesAsync();

            return Ok();
        }


    }
}
