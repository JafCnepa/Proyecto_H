using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PM_Trabajo_Final_Hospital.Models
{
    public class Farmacias
    {
        [Key]
        public int IdFarmacia { get; set; }
        [Display(Name = "Nombre ")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]
        public string? Nombre { get; set; }

        [ForeignKey("Departamento")]
        public int IdDepartamento { get; set; }
        [ForeignKey("Distrito")]
        public int IdDistrito { get; set; }

        public virtual Departamento Departamento { get; set; }
        public virtual Distrito Distrito { get; set; }
    }
}
