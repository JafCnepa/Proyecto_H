using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PM_Trabajo_Final_Hospital.Models
{
    public class CitaReservas
    {
        [Key]
        public int IdCita { get; set; }
        [ForeignKey("Medicos")]
        public int IdMedico { get; set; }
        [ForeignKey("Usuarios")]
        public int UsuarioId { get; set; }

        public virtual Medico Medico { get; set; }
        public virtual Usuario Usuario { get; set; }

    }
}
