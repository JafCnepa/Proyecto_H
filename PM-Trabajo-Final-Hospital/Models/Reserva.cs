using System;
using System.Collections.Generic;

namespace PM_Trabajo_Final_Hospital.Models
{
    public partial class Reserva
    {
        public int IdReserva { get; set; }
        public int IdMedico { get; set; }
        public int IdMedicamento { get; set; }

        public virtual Medicamento IdMedicamentoNavigation { get; set; }
        public virtual Medico IdMedicoNavigation { get; set; }
    }
}
