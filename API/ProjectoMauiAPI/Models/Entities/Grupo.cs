using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectoMauiAPI.Models.Entities
{
    public class Grupo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdGrupo { get; set; }

        [Required]
        public string DescripcionGrupo { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;


    }
}
