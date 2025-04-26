using Microsoft.AspNetCore.Mvc;
 using Microsoft.EntityFrameworkCore;
 using ProjectoMauiAPI.Data;
 using ProjectoMauiAPI.Models.Entities;
 using BCrypt.Net;
 using System.Text.Json;

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
            var existe = await _demoDbContext.Usuarios
                .AnyAsync(u => u.CorreoUsuario == usuario.CorreoUsuario);

            if (existe)
            {
                return BadRequest("El correo ya está en uso.");
            }

            // Encriptar la contraseña antes de guardarla
            usuario.ContrasenaUsuario = BCrypt.Net.BCrypt.HashPassword(usuario.ContrasenaUsuario);

            await _demoDbContext.Usuarios.AddAsync(usuario);
            await _demoDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { idusuario = usuario.IdUsuario }, usuario);
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

        [HttpGet("buscar-por-cedula")]
        public async Task<ActionResult<Usuario>> BuscarUsuarioPorCedula(string cedula)
        {
            var usuario = await _demoDbContext.Usuarios
                .FirstOrDefaultAsync(u => u.CedulaUsuario == cedula);

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }


        public class LoginRequest
        {
            public string Correo { get; set; }
            public string Contrasena { get; set; }
        }

        [HttpPost("login")]
        public async Task<ActionResult<Usuario>> Login([FromBody] LoginRequest loginData)
        {
            if (loginData == null || string.IsNullOrEmpty(loginData.Correo) || string.IsNullOrEmpty(loginData.Contrasena))
            {
                return BadRequest("Faltan campos requeridos: 'Correo' o 'Contrasena'.");
            }

            var usuario = await _demoDbContext.Usuarios
                .FirstOrDefaultAsync(u => u.CorreoUsuario == loginData.Correo);

            if (usuario == null)
                return Unauthorized("Correo o contraseña incorrectos");

            bool contrasenaValida = BCrypt.Net.BCrypt.Verify(loginData.Contrasena, usuario.ContrasenaUsuario);

            if (!contrasenaValida)
                return Unauthorized("Correo o contraseña incorrectos");

            return Ok(usuario);
        }


    }
}
    