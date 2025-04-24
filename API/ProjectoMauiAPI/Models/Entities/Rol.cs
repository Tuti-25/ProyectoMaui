using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace ProjectoMauiAPI.Models.Entities
{
    [Table("Roles")]
    public class Rol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdRol")]
        public int IdRol { get; set; }

        [Column("TipoRol")]
        [MaxLength(50)]
        public string? TipoRol { get; set; }

        [Column("DescripcionRol")]
        public string? DescripcionRol { get; set; }

        public ICollection<AgenteRoles>? AgenteRoles { get; set; }
    }
}
