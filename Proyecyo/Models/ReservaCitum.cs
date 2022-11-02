using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecyo.Models
{
    public partial class ReservaCitum
    {
        [Key]

        public int IdCita { get; set; }
        [ForeignKey("Medico")]
        public int IdMedico { get; set; }
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        [Display(Name = "Reservar Fecha")]
        [Required(ErrorMessage = "Este campo requiere fecha nacimiento")]
        [DataType(DataType.Date)]
        public DateTime? FechaReserva { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
