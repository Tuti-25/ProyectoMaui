using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace ProjectoMauiAPI.Models.Entities
{
    public class Notificacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdNotificacion { get; set; }

        [Required]
        public int IdUsuario { get; set; }
        public int? IdMensaje { get; set; }
        public int? IdCaso { get; set; }

        [Required]
        [MaxLength(50)]
        public string TipoNotificacion { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.UtcNow;


        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [ForeignKey("IdMensaje")]
        public Mensaje Mensaje { get; set; }

        [ForeignKey("IdCaso")]
        public Caso Caso { get; set; }


    }   
}
