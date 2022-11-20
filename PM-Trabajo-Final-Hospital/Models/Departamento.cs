using System.ComponentModel.DataAnnotations;

namespace PM_Trabajo_Final_Hospital.Models
{
    public class Departamento
    {
        [Key]
        public int IdDepartamento { get; set; }

        public string? Departamentos { get; set; }
    }
}
