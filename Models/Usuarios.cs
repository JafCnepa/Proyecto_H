using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class Usuarios
    {

        [Key]
        public int id_usuario { get; set; }
        [Required]
        public string? nombre { get; set; }

        [Required]

        public string? apellido { get; set; }
        [Required]
        public char? dni { get; set; }
        [Required]
        public char? ruc { get; set; }
        [Required]
        public char? celular { get; set; }

        [Required]


        public string? correo { get; set; }
        [Required]
        public DateTime? fecha_nacimiento { get; set; }
        public string? descripcion { get; set; }
        public string? clave { get; set; }

        public virtual ICollection<Medico> Medico { get; set; }


    }
}