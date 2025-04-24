using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ProjectoMauiAPI.Models.Entities
{
    [Table("Casos")]
    public class Caso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdCaso")]
        public int IdCaso { get; set; }

        [Column("DescripcionCaso")]
        [MaxLength(500)]
        public string? DescripcionCaso { get; set; }

        [Column("IdUsuario")]
        public int IdUsuario { get; set; }

        [Column("IdAgente")]
        public int IdAgente { get; set; }

        [Column("IdSeveridad")]
        public int IdSeveridad { get; set; }

        [Column("IdEstado")]
        public int IdEstado { get; set; }

        [Column("FechaCreacion")]
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        [Column("FechaFinalizacion")]
        public DateTime? FechaFinalizacion { get; set; }

        [Column("FechaActualizacion")]
        public DateTime? FechaActualizacion { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }

        [ForeignKey("IdAgente")]
        public Agente? Agente { get; set; }

        [ForeignKey("IdSeveridad")]
        public Severidad? Severidad { get; set; }

        [ForeignKey("IdEstado")]
        public EstadoCaso? EstadoCaso { get; set; }
    }
}
