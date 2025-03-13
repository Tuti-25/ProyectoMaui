using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectoMauiAPI.Models.Entities
{
    public class UsuarioGrupo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuarioGrupo { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        public int IdGrupo { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [ForeignKey("IdGrupo")]
        public Grupo Grupo { get; set; }
    }
}

