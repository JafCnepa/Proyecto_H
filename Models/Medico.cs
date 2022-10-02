using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class Medico
    {
        [Key]
        public int id_medico { get; set; }
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        [Required]
        public string? especialidad { get; set; }
        [Required]
        public char? cedula { get; set; }
        public string? salon { get; set; }
    }
}