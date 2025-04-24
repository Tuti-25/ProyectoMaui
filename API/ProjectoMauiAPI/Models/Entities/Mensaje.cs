using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectoMauiAPI.Models.Entities
{
    [Table("Mensajes")]
    public class Mensaje
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdMensaje")]
        public int IdMensaje { get; set; }

        [Column("IdUsuario")]
        public int IdUsuario { get; set; }

        [Column("IdCaso")]
        public int? IdCaso { get; set; }

        [Column("IdGrupo")]
        public int? IdGrupo { get; set; }

        [Column("IdTipoMensaje")]
        public int IdTipoMensaje { get; set; }

        [Column("DescripcionMensaje")]
        public string? DescripcionMensaje { get; set; }

        [Column("FechaMensaje")]
        public DateTime FechaMensaje { get; set; } = DateTime.UtcNow;

        [ForeignKey("IdCaso")]
        public Caso? Caso { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [ForeignKey("IdGrupo")]
        public Grupo? Grupo { get; set; }

        [ForeignKey("IdTipoMensaje")]
        public TipoMensaje TipoMensaje { get; set; }
    }
}
