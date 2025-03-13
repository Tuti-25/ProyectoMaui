using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectoMauiAPI.Models.Entities
{
    public class Rol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRol { get; set; }

        [Required]
        [MaxLength(50)]
        public string TipoRol { get; set; }
        public string DescripcionRol { get; set; }
    }
}
