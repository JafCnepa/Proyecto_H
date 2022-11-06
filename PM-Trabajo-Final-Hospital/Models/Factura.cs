using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PM_Trabajo_Final_Hospital.Models
{
    public partial class Factura
    {
        [Key]
        public int IdFactura { get; set; }

        public string? Nombres { get; set; }
        public string? Direccion { get; set; }
        public decimal Total { get; set; }
        public string? Estado { get; set; }
        public DateTime Fecha { get; set; }
        [ForeignKey("Usuarios")]
        public int IdUsuario { get; set; }
        [ForeignKey("Medicamentos")]
        public int IdMedicamento { get; set; }

        public virtual Medicamento IdMedicamentoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
