using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectoMauiAPI.Models.Entities
{
    public class Usuario
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }

        [Required]
        [MaxLength(100)]
        public string NombreUsuario { get; set; }

        [Required]
        [MaxLength(5)]
        public string CodigoCasa { get; set; }

        [Required]
        [MaxLength(100)]
        public string ApellidoUsuario { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(200)]
        public string CorreoUsuario { get; set; }

        [Required]
        [Phone]
        [MaxLength(20)]
        public string TelefonoUsuario { get; set; }

        [Required]
        public string UbicacionUsuario { get; set; }

        [Required]
        [MaxLength(30)]
        public string CedulaUsuario { get; set; }

        [Required]
        [MaxLength(255)]
        public string ContrasenaUsuario { get; set; }

    }

}

