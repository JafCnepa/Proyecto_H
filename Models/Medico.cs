using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;
namespace Proyecto.Models

{
    public class Medico
    {
        [Key]
        public int id_medico { get; set; }
        [Required]

        public string? nombre { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8)]

        public string? apellido { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8)]

        public string? especialidad { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8)]

        public string? cedula { get; set; }
        [Required]
        [StringLength(8)]


   
        public string? salon { get; set; }


    }
}
