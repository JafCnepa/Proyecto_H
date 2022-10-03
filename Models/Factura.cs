using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.Models
{
    public class Factura
    {
        [Key]
        public int id_factura { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8)]
        public string? nombre { get; set; }
        [Required]
        [StringLength(1000, MinimumLength = 1)]
        public char?  stock { get; set; }
        [Column(TypeName = "money")]
        public decimal precio { get; set; }
        [StringLength(10, MinimumLength = 1)]
        public string? categoria { get; set; }
        public DateTime fecha { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; }

    } 
}
