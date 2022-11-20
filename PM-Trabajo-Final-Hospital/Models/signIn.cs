using System.ComponentModel.DataAnnotations;

namespace PM_Trabajo_Final_Hospital.Models
{
    public class signIn
    {
        [Required(ErrorMessage = "El usuario es obligatorio")]
    
        public string? Usuario1 { get; set; }

        [Required(ErrorMessage = "La  clave es obligatorio")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string? Password { get; set; }

        [Display(Name = "Recordar datos?")]
        public bool RememberMe { get; set; }
    }
}
