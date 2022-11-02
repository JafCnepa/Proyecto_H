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
        [ForeignKey("Medicamento")]
        public int IdMedicamento { get; set; }
        [Display(Name = "Stock ")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(100, ErrorMessage = "Longitud máxima 100", MinimumLength = 1)]
        public string Stock { get; set; }

        public virtual Medicamento IdMedicamentoNavigation { get; set; }
    }
}
