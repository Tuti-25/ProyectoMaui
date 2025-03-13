using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectoMauiAPI.Models.Entities
{
    public class Caso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCaso { get; set; }

        [Required]
        [MaxLength(500)]
        public string DescripcionCaso { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        public int IdAgente { get; set; }

        [Required]
        public int IdSeveridad { get; set; }

        [Required]
        public int IdEstado { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        public DateTime? FechaFinalizacion { get; set; }

        public DateTime? FechaActualizacion { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [ForeignKey("IdAgente")]
        public Agente Agente { get; set; }

        [ForeignKey("IdSeveridad")]
        public Severidad Severidad { get; set; }

        [ForeignKey("IdEstado")]
        public EstadoCaso EstadoCaso { get; set; }
    }
}
