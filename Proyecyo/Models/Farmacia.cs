using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyecyo.Models
{
    public partial class Farmacia
    {
        public Farmacia()
        {
            Medicamentos = new HashSet<Medicamento>();
        }
        [Key]
        public int IdFarmacia { get; set; }
        [Required, StringLength(20, MinimumLength = 4)]
        public string? Nombre { get; set; }
        [Required, StringLength(10, MinimumLength = 4)]
        public string? Pais { get; set; }
        [Required, StringLength(20, MinimumLength = 4)]
        public string? Departamento { get; set; }
        [Required, StringLength(50, MinimumLength = 4)]
        public string? Distrito { get; set; }

        public virtual ICollection<Medicamento> Medicamentos { get; set; }
    }
}
