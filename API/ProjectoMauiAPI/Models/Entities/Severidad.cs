using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace ProjectoMauiAPI.Models.Entities
{
    public class Severidad

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSeveridad { get; set; }

        [Required]
        [Range(1, 4)]
        public int TipoSeveridad { get; set; }

        [Required]
        public string DescripcionSeveridad { get; set; }

    }
}
