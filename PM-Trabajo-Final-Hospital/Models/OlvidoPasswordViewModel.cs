using System.ComponentModel.DataAnnotations;

namespace PM_Trabajo_Final_Hospital.Models
{
    public class OlvidoPasswordViewModel
    {
        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
