using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace ProjectoMauiAPI.Models.Entities
{
    public class Agente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAgente { get; set; }

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

        // Relación muchos a muchos con Roles
        public ICollection<AgenteRoles> AgenteRoles { get; set; }
    }
}
