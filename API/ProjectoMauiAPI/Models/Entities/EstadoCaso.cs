using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace ProjectoMauiAPI.Models.Entities
{
    [Table("EstadosCaso")]
    public class EstadoCaso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdEstado")]
        public int IdEstado { get; set; }

        [Column("DescripcionEstado")]
        [MaxLength(100)]
        public string? DescripcionEstado { get; set; }
    }
}
