using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class Medico
    {
        [Key]
        public int id_medico { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8)]
        public string? nombre { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8)]
        public string? apellido { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8)]
        public string? especialidad { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 8)]
        public char? cedula { get; set; }

        [StringLength(5, MinimumLength = 1)]
        public string? salon { get; set; }
    }
}