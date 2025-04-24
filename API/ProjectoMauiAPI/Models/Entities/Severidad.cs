using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Globalization;

namespace ProjectoMauiAPI.Models.Entities
{
    [Table("Severidades")]
    public class Severidad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdSeveridad")]
        public int IdSeveridad { get; set; }

        [Column("TipoSeveridad")]
        [Range(1, 4)]
        public int? TipoSeveridad { get; set; }

        [Column("DescripcionSeveridad")]
        public string? DescripcionSeveridad { get; set; }
    }
}
