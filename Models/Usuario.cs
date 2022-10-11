using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Proyecto.Models
{
    public class Usuario
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
        public string? dni { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 8)]
        public string? ruc { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 9)]
        public string? celular { get; set; }

        [Required]

        [EmailAddress(ErrorMessage = "Los datos deben coincidir")]
        public string? correo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? fecha_nacimiento { get; set; }
        [PasswordPropertyText]
        public string? clave { get; set; }
    }
}
