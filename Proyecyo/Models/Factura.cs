using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecyo.Models
{
    public partial class Factura
    {
        [Key]
        public int IdFactura { get; set; }

        [Display(Name = "Nombre Factura ")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]

        public string? Nombre { get; set; }

        [Display(Name = "Direccion")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]


        public string? Direccion { get; set; }


        [Display(Name = "Total")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(100, ErrorMessage = "Longitud máxima 100", MinimumLength = 1)]

        public string? Total { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 9)]


        public string? Estado { get; set; }

        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "Este campo requiere la fecha de la factura")]
        [DataType(DataType.Date)]



        public DateTime? Fecha { get; set; }
        public int IdUsuario { get; set; }
        public int IdMedicamento { get; set; }

        public virtual Medicamento IdMedicamentoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
