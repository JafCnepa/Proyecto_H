using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecyo.Models
{
    public partial class Medicamento
    {
        public Medicamento()
        {
            Facturas = new HashSet<Factura>();
            ReservaMedicamentos = new HashSet<ReservaMedicamento>();
        }
        [Key]
        public int IdMedicamento { get; set; }
        [Required, StringLength(20, MinimumLength = 5)]

        public string? Nombre { get; set; }
        [Required, StringLength(1000, MinimumLength = 1)]
        public string? Stock { get; set; }
        [Required, StringLength(100, MinimumLength = 1)]
        public string? Categoria { get; set; }
        [Required, StringLength(100, MinimumLength = 1)]
        public string? Precio { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Se requiere la fecha")]
        public DateTime? Fecha { get; set; }
        [ForeignKey("IdUsuario")]
        public int IdUsuario { get; set; }
        [ForeignKey("IdFarmacia")]
        public int IdFarmacia { get; set; }

        public virtual Farmacia IdFarmaciaNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<Factura> Facturas { get; set; }
        public virtual ICollection<ReservaMedicamento> ReservaMedicamentos { get; set; }
    }
}
