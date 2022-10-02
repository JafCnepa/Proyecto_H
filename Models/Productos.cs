using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class Productos
    {
        [Key]
        public int id_productos { get; set; }
        [Required]
        public string? nombre { get; set; }
        public int? stock { get; set; }
        [Required]
        public char? precio { get; set; }
        public string? categoria { get; set; }
        public DateTime fecha { get; set; }
        [Required]
        public virtual ICollection<Usuarios> Usuarios { get; set; }


    }
}