using Microsoft.EntityFrameworkCore;
using ProjectoMauiAPI.Models.Entities;

namespace ProjectoMauiAPI.Data
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Agente> Agentes { get; set; }
        public DbSet<Archivo> Archivos { get; set; }
        public DbSet<Caso> Casos { get; set; }
        public DbSet<EstadoCaso> EstadosCasos { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Mensaje> Mensajes { get; set; }
        public DbSet<Notificacion> Notificaciones { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Severidad> Severidades { get; set; }
        public DbSet<TipoMensaje> TipoMensajes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioGrupo> UsuarioGrupos { get; set; }


    }
}
