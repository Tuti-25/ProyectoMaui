using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace ProjectoMauiAPI.Models.Entities
{
    [Table("Agentes")]
    public class Agente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdAgente")]
        public int IdAgente { get; set; }

        [Column("NombreAgente")]
        [MaxLength(100)]
        public string? NombreAgente { get; set; }

        [Column("ApellidoAgente")]
        [MaxLength(100)]
        public string? ApellidoAgente { get; set; }

        [Column("TelefonoAgente")]
        [Phone]
        [MaxLength(20)]
        public string? TelefonoAgente { get; set; }

        [Column("CedulaAgente")]
        [MaxLength(50)]
        public string? CedulaAgente { get; set; }

        public ICollection<AgenteRoles>? AgenteRoles { get; set; }
    }
}

