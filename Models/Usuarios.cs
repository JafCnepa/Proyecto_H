using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class Usuarios
    {

        [Key]
        public int id_usuario { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8)]
        public string? nombre { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 8)]
        public string? apellido { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 8)]
        public char? dni { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 8)]
        public char? ruc { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 9)]
        public char? celular { get; set; }

        [Required]

        [EmailAddress]
        public string? correo { get; set; }
        [Required]
        public DateTime? fecha_nacimiento { get; set; }
        [StringLength(1000, MinimumLength = 1)]
        public string? descripcion { get; set; }
        [PasswordPropertyText]
        public string? clave { get; set; }

        public virtual ICollection<Medico> Medico { get; set; }


    }
}