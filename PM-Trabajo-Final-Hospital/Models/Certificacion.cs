using System.ComponentModel.DataAnnotations;

namespace PM_Trabajo_Final_Hospital.Models
{
    public class Certificacion
    {
        [Key]
        public int IdCertificacion { get; set; }
        public string Certificaciones { get; set; }
    }
}
