using System.ComponentModel.DataAnnotations;

namespace PM_Trabajo_Final_Hospital.Models
{
    public class Distrito
    {
        [Key]
        public int IdDistrito { get; set; }
        public string? Distritos { get; set; }

    }
}
