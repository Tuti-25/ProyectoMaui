using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace ProjectoMauiAPI.Models.Entities
{
    [Table("Notificaciones")]
    public class Notificacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdNotificacion")]
        public int IdNotificacion { get; set; }

        [Column("IdUsuario")]
        public int IdUsuario { get; set; }

        [Column("IdMensaje")]
        public int? IdMensaje { get; set; }

        [Column("IdCaso")]
        public int? IdCaso { get; set; }

        [Column("TipoNotificacion")]
        [MaxLength(50)]
        public string? TipoNotificacion { get; set; }

        [Column("Fecha")]
        public DateTime Fecha { get; set; } = DateTime.UtcNow;

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [ForeignKey("IdMensaje")]
        public Mensaje? Mensaje { get; set; }

        [ForeignKey("IdCaso")]
        public Caso? Caso { get; set; }
    }
}
