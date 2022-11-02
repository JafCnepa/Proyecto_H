using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecyo.Models
{
    public partial class Medico
    {
        public Medico()
        {
            ReservaCita = new HashSet<ReservaCitum>();
        }

        [Key]
        public int IdMedico { get; set; }

        [Display(Name = "Nombre Completo ")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]
        public string? Nombrecompletodoctor { get; set; }
        [Display(Name = "Especialidad ")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]
        public string? Especialidad { get; set; }
        [Display(Name = "Dni")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(8, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]

        public string? Dnidoctor { get; set; }
        [Display(Name = "Certificado ")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]

        public string? Certificado { get; set; }
        [Display(Name = "Ubicacion ")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]
        public string? Ubicacion { get; set; }

        public int IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<ReservaCitum> ReservaCita { get; set; }
    }
}
