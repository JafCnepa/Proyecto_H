using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PM_Trabajo_Final_Hospital.Models
{
    public class Usuario:  IdentityUser
    {
       
        public int UsuarioId { get; set; }
        [Display(Name = "Nombre  Completo")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]
        public string? Nombrecompletousuario { get; set; }
        [Display(Name = "Dni")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(8, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]
        public string? Dniusuario { get; set; }
        [Display(Name = "Ruc")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(9, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]
        public string? Rucusuario { get; set; }
        [Display(Name = "Celular")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(20, ErrorMessage = "Longitud máxima 50", MinimumLength = 9)]
        public string? Celularusuario { get; set; }
        [Display(Name = "Fecha Nacimiento")]
        [Required(ErrorMessage = "Este campo requiere fecha")]
        [DataType(DataType.Date)]
        public DateTime? FechaNacimiento { get; set; }
        [Display(Name = "Usuario ")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]

        public bool Estado { get; set; }

        [NotMapped]

        public IFormFile toBase64 { get; set; }
        public string? Foto { get; set; }
        public string? Usuario1 { get; set; }
        public int DetalleUsuario_Id { get; set; }
        [ForeignKey("Detalle_Usuario")]
        public virtual DetalleUsuario DetalleUsuario { get; set; }
    }
}
