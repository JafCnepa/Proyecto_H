using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace Proyecto.Models
{
    public class Producto
    {
        [Key]
        public int id_producto { get; set; }
        [Required, StringLength(10, MinimumLength = 5)]
        public string? nombre { get; set; }
        [Required,StringLength(10, MinimumLength = 5)]
        public string? stock { get; set; }
        [Required,  StringLength(100, MinimumLength = 1)]
        public string? categoria { get; set; }
        [Required, StringLength(1000, MinimumLength = 1)]
        public string? precio { get; set; }
       
        [DataType(DataType.Date)]
        [Required, StringLength(1000, MinimumLength = 1)]
        public DateTime? fecha { get; set; }
        [ForeignKey("id_usuario")]
        public int id_usuario { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }

        [ForeignKey("id_farmacias")]
        public int id_farmacias { get; set; }
        public ICollection<Farmacia> Farmacias { get; set; }


    }
}
