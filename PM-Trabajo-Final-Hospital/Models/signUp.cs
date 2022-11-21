using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PM_Trabajo_Final_Hospital.Models
{
    public class signUp
    {
        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [StringLength(50, ErrorMessage = "El {0} debe estar entre al menos {2} caracteres de longitud", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required(ErrorMessage = "La confirmación de contraseña es obligatoria")]
        [Compare("Password", ErrorMessage = "La contraseña y confirmación de contraseña no coinciden")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        public string ConfirmPassword { get; set; }

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
        [StringLength(9, ErrorMessage = "Longitud máxima 50", MinimumLength = 9)]
        public string? Rucusuario { get; set; }
        [Display(Name = "Celular")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(20, ErrorMessage = "Longitud máxima 50", MinimumLength = 9)]
        public string? Celularusuario { get; set; }
        [Display(Name = "Fecha Nacimiento")]
        [Required(ErrorMessage = "Este campo requiere fecha")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        public bool Estado { get; set; }
        public string? Usuario1 { get; set; }

        public IFormFile toBase64 { get; set; }
        public string? Foto { get; set; }
        //Para selección de roles
        [Display(Name = "Seleccionar rol")]
        public IEnumerable<SelectListItem> ListaRoles { get; set; }
        [Display(Name = "Rol seleccionado")]
        public string RolSeleccionado { get; set; }
    }
}
