using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Display(Name = "Nombre Farmacia ")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 4)]
        public string? Nombrefarmacia { get; set; }

        [Display(Name = "Pais Farmacia ")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 4)]
        public string? Pais { get; set; }
        [Display(Name = "Depertamento Farmacia ")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 4)]

        public string? Departamento { get; set; }
        [Display(Name = "Distrito Farmacia ")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 4)]


        public string? Distrito { get; set; }

        public virtual ICollection<Medicamento> Medicamentos { get; set; }
    }
}
