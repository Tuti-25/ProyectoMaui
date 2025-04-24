using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ProjectoMauiAPI.Models.Entities
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdUsuario")]
        public int IdUsuario { get; set; }

        [Column("NombreUsuario")]
        [MaxLength(100)]
        public string? NombreUsuario { get; set; }

        [Column("CodigoCasa")]
        [MaxLength(5)]
        public string? CodigoCasa { get; set; }

        [Column("ApellidoUsuario")]
        [MaxLength(100)]
        public string? ApellidoUsuario { get; set; }

        [Column("CorreoUsuario")]
        [EmailAddress]
        [MaxLength(200)]
        public string? CorreoUsuario { get; set; }

        [Column("TelefonoUsuario")]
        [Phone]
        [MaxLength(20)]
        public string? TelefonoUsuario { get; set; }

        [Column("CedulaUsuario")]
        [MaxLength(30)]
        public string? CedulaUsuario { get; set; }

        [Column("ContrasenaUsuario")]
        [MaxLength(255)]
        public string? ContrasenaUsuario { get; set; }
    }
}

