using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace PM_Trabajo_Final_Hospital.Models
{
    public partial class Medico
    {
        public Medico()
        {
            Reservas = new HashSet<Reserva>();
        }
        [Key]
        public int IdMedico { get; set; }
        [Display(Name = "Nombre ")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]
        public string? Nombre { get; set; }
        [Display(Name = "Apellido Doctor ")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]
        public string? Apellido { get; set; }
        [Display(Name = "Especialidad ")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]
        public string? Especialidad { get; set; }

        [Display(Name = "Dni")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(8, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]
        public string? DniMedico { get; set; }

        [Display(Name = "Certificado ")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]
        public string? Certificado { get; set; }

        [Display(Name = "Salon ")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]
        public string? Salon { get; set; }

        [Display(Name = "Fecha Cita")]
        [Required(ErrorMessage = "Este campo requiere fecha nacimiento")]
        [DataType(DataType.Date)]
        public DateTime? Fecha { get; set; }
        [ForeignKey("Usuarios")]
        public int IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
