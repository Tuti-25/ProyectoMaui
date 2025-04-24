using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace ProjectoMauiAPI.Models.Entities
{
    [Table("Archivos")]
    public class Archivo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdArchivo")]
        public int IdArchivo { get; set; }

        [Column("IdMensaje")]
        public int IdMensaje { get; set; }

        [Column("NombreArchivo")]
        [MaxLength(255)]
        public string? NombreArchivo { get; set; }

        [Column("RutaArchivo")]
        public string? RutaArchivo { get; set; }

        [Column("TipoArchivo")]
        [MaxLength(50)]
        public string? TipoArchivo { get; set; }

        [ForeignKey("IdMensaje")]
        public Mensaje? Mensaje { get; set; }
    }
}

