using System.ComponentModel.DataAnnotations;

namespace PM_Trabajo_Final_Hospital.Models
{
    public class Colegiado
    {
        [Key]
        public int IdColegiado { get; set; }
        public string Colegiados { get; set; }
    }
}
