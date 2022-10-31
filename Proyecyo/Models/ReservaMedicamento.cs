using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecyo.Models
{
    public partial class ReservaMedicamento
    {
        [Key]
        public int IdReservamedicamento { get; set; }
        [ForeignKey("IdMedicamento")]
        public int IdMedicamento { get; set; }

        public virtual Medicamento IdMedicamentoNavigation { get; set; } 
    }
}
