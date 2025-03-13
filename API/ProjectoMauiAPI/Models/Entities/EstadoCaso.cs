using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectoMauiAPI.Models.Entities
{
    public class EstadoCaso
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstado { get; set; }

        [Required]
        [MaxLength(100)]
        public string DescripcionEstado { get; set; }


    }
}
