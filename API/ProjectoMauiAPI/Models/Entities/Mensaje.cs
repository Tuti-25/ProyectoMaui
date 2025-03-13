using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectoMauiAPI.Models.Entities
{
    public class Mensaje
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMensaje { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        public int? IdCaso { get; set; }

        public int? IdGrupo { get; set; }

        [Required]
        public int IdTipoMensaje { get; set; }

        [Required]
        public string DescripcionMensaje { get; set; }

        [Required]
        public DateTime FechaMensaje { get; set; } = DateTime.UtcNow;

        [ForeignKey("IdCaso")]
        public Caso Caso { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [ForeignKey("IdGrupo")]
        public Grupo Grupo { get; set; }

        [ForeignKey("IdTipoMensaje")]
        public TipoMensaje TipoMensaje { get; set; }
    }
}
