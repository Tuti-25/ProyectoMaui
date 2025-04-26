using Microsoft.AspNetCore.Mvc;
using ProjectoMauiAPI.Data;
using ProjectoMauiAPI.Models.Entities;

namespace Demo.ApiClient2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseController : ControllerBase
    {
        private readonly DemoDbContext _demoDbContext;

        public CaseController(DemoDbContext demoDbContext)
        {
            _demoDbContext = demoDbContext;
        }

        public class CaseModesl
        {
            public string DescripcionCaso { get; set; }
            public int IdUsuario { get; set; }
            public int IdSeveridad { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> CrearCaso([FromBody] CaseModesl data)
        {
            if (data == null)
            {
                return BadRequest("No se recibieron datos.");
            }

            string descripcion = data.DescripcionCaso;
            int idUsuario = data.IdUsuario;
            int idSeveridad = data.IdSeveridad;

            return Ok(new
            {
                Message = "Caso creado correctamente",
                Datos = new
                {
                    descripcion,
                    idUsuario,
                    idSeveridad
                }
            });


        }
    }
}
