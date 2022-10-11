using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [StringLength(8, MinimumLength = 8)]

        public string? dni { get; set; }
    
        [StringLength(20, MinimumLength =1)]
        public string? certificado { get; set; }

        [ForeignKey("id_usuario")]
        public int id_usuario { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }

    }
}
