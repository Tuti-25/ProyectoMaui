using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace ProjectoMauiAPI.Models.Entities
{
    [Table("TipoMensajes")]
    public class TipoMensaje
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdTipoMensaje")]
        public int IdTipoMensaje { get; set; }

        [Column("FormatoMensaje")]
        [MaxLength(50)]
        public string? FormatoMensaje { get; set; }
    }
}
