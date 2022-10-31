using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


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
        public string? NombrecompletoDoctor { get; set; }
        [Display(Name = "Especialidad ")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]
        public string Especialidad { get; set; }
        [Display(Name = "Dni")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 4)]
        public string? DniDoctor { get; set; }
        [Display(Name = "Certificado ")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]
        public string? Certificado { get; set; }
        public int IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<ReservaCitum> ReservaCita { get; set; }
    }
}