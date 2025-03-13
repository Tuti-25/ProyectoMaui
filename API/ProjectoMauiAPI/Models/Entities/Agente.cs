using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectoMauiAPI.Models.Entities
{
    public class Agente
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAgente { get; set; }

        [Required]
        public int IdRol { get; set; }

        [Required]
        [MaxLength(100)]
        public string NombreAgente { get; set; }

        [Required]
        [MaxLength(100)]
        public string ApellidoAgente { get; set; }

        [Required]
        [Phone]
        [MaxLength(20)]
        public string TelefonoAgente { get; set; }

        [Required]
        [MaxLength(50)]
        public string CedulaAgente { get; set; }

        [ForeignKey("IdRol")]
        public Rol Rol { get; set; }

    }
}
