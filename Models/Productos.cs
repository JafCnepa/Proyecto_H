using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.Models
{
    public class Productos
    {
        [Key]
        public int id_productos { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8)]
        public string? nombre { get; set; }
        [StringLength(100, MinimumLength = 1)]
        public int? stock { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal precio { get; set; }
        [StringLength(5, MinimumLength = 1)]
        public string? categoria { get; set; }

        public DateTime fecha { get; set; }
        [Required]
        public virtual ICollection<Usuarios> Usuarios { get; set; }


    }
}