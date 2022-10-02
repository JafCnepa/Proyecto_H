using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class Factura
    {
        [Key]
        public int id_factura { get; set; }
        [Required]
        public string? nombre { get; set; }
        [Required] 
        public char?  stock { get; set; }
        public char? precio { get; set; }
        [Required]
        public string categoria { get; set; }
        public DateTime fecha { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; }

    } 
}
