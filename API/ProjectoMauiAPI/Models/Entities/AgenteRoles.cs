using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectoMauiAPI.Models.Entities
{
    public class AgenteRoles
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdAgente { get; set; }

        [Required]
        public int IdRol { get; set; }

        [ForeignKey("IdAgente")]
        public Agente Agente { get; set; }

        [ForeignKey("IdRol")]
        public Rol Rol { get; set; }
    }
}

