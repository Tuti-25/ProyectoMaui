using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace ProjectoMauiAPI.Models.Entities
{
    [Table("AgenteRoles")]
    public class AgenteRoles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [Column("IdAgente")]
        public int IdAgente { get; set; }

        [Column("IdRol")]
        public int IdRol { get; set; }

        [ForeignKey("IdAgente")]
        public Agente? Agente { get; set; }

        [ForeignKey("IdRol")]
        public Rol? Rol { get; set; }
    }
}
