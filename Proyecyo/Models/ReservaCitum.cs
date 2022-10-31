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
        [ForeignKey("IdMedico")]
        public int IdMedico { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; } 
    }
}
