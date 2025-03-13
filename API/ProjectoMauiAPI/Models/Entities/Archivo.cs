using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectoMauiAPI.Models.Entities
{
    public class Archivo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdArchivo { get; set; }

        [Required]
        public int IdMensaje { get; set; }

        [Required]
        [MaxLength(255)]
        public string NombreArchivo { get; set; }

        [Required]
        public string RutaArchivo { get; set; }

        [Required]
        [MaxLength(50)]
        public string TipoArchivo { get; set; }

        [ForeignKey("IdMensaje")]
        public Mensaje Mensaje { get; set; }
    }
}
