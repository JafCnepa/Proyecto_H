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

        public string? apellido { get; set; }
        [Required]

        public string? especialidad { get; set; }
        [Required]

        public char? cedula { get; set; }


        public char? salon { get; set; }
    }
}
