using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;
using System.ComponentModel.DataAnnotations.Schema;

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
        public DateTime? fecha_nacimiento { get; set; }
        [StringLength(1000, MinimumLength = 1)]
        public string? descripcion { get; set; }
        [PasswordPropertyText]
        public string? clave { get; set; }
        [ForeignKey("id_medico")]
        public int id_medico { get; set; }

        public virtual ICollection<Medico> Medico { get; set; }
    }
}
