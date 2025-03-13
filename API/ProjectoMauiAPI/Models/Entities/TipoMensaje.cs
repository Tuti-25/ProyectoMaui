using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectoMauiAPI.Models.Entities
{
    public class TipoMensaje
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoMensaje { get; set; }

        [Required]
        [MaxLength(50)]
        public string FormatoMensaje {get; set; }
    }
}
