using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyecyo.Models
{
    public partial class Factura
    {
        [Key]
        public int IdFactura { get; set; }
        [Display(Name = "Nombre Factura ")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]
        public string? NombreFactura { get; set; }
        [Display(Name = "Dni")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]
        public string? DniUsuario { get; set; }
        [Display(Name = "Ruc")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]
        public string? RucUsuario { get; set; }
        [Display(Name = "Direccion")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]
        public string? DireccionUsuario { get; set; }
        [Display(Name = "Celular")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(20, ErrorMessage = "Longitud máxima 20", MinimumLength = 9)]
        public string? CelularUsuario { get; set; }
        [Display(Name = "Total")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(100, ErrorMessage = "Longitud máxima 100", MinimumLength = 9)]
        public string? Total { get; set; }
        [Display(Name = "Tipo Pago")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(100, ErrorMessage = "Longitud máxima 50", MinimumLength = 20)]
        public string? TipoPago { get; set; }
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