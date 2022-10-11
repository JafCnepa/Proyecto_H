using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class Farmacia
    {
        [Key]
        public int id_farmacia { get; set; }
        [Required, StringLength(20, MinimumLength = 5)]
        public string? nombre { get; set; }
        [Required, StringLength(30, MinimumLength = 5)]
        public string? ubicacion { get; set; }
         
    }
}
