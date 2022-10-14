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
        [Required, StringLength(20, MinimumLength = 5)]
        public string? Nombre { get; set; }
        [Required, StringLength(8, MinimumLength = 8)]
        public string? Dni { get; set; }

        [Required, StringLength(15, MinimumLength = 9)]
        public string? Ruc { get; set; }
        [Required, StringLength(20, MinimumLength = 5)]
        public string? Direccion { get; set; }

        [Required, StringLength(20, MinimumLength = 9)]
        public string? Telefono { get; set; }
        [Required, StringLength(1000, MinimumLength = 1)]
        public string? Total { get; set; }
        [Required, StringLength(200, MinimumLength = 1)]
        public string? TipoPago { get; set; }
        [Required, StringLength(200, MinimumLength = 5)]
        public string? Estado { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime? Fecha { get; set; }
        [ForeignKey("IdUsuario")]
        public int IdUsuario { get; set; }
        [ForeignKey("IdMedicamento")]
        public int IdMedicamento { get; set; }

        public virtual Medicamento IdMedicamentoNavigation { get; set; } 
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
