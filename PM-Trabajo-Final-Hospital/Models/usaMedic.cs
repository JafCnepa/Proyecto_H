using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PM_Trabajo_Final_Hospital.Models
{
    public class usaMedic
    {
        
        [ForeignKey("Medicos")]
        public int IdMedico { get; set; }
        [ForeignKey("Medicamentos")]
        public int IdMedicamento { get; set; }

        public virtual Medico Medico { get; set; }
        public virtual Medicamentos Medicamento { get; set; }
    }
}
