using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace ProjectoMauiAPI.Models.Entities
{
    [Table("UsuarioGrupos")]
    public class UsuarioGrupo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdUsuarioGrupo")]
        public int IdUsuarioGrupo { get; set; }

        [Column("IdUsuario")]
        public int? IdUsuario { get; set; }

        [Column("IdGrupo")]
        public int? IdGrupo { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }

        [ForeignKey("IdGrupo")]
        public Grupo? Grupo { get; set; }
    }
}
