﻿
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

        [Display(Name = "Nombre Medicamento ")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(100, ErrorMessage = "Longitud máxima 100", MinimumLength = 8)]
        public string? Nombremedicamento { get; set; }
        [Display(Name = "Stock ")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(100, ErrorMessage = "Longitud máxima 100", MinimumLength = 1)]

        public string? Stock { get; set; }
        [Display(Name = "Categoria ")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(100, ErrorMessage = "Longitud máxima 100", MinimumLength = 2)]
        public string? Categoria { get; set; }

        [Display(Name = "Precio ")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(100, ErrorMessage = "Longitud máxima 100", MinimumLength = 1)]
        public string? Precio { get; set; }

        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "Este campo requiere fecha del medicamento")]
        [DataType(DataType.Date)]
        public DateTime? Fecha { get; set; }
        public int IdUsuario { get; set; }
        public int IdFarmacia { get; set; }

        public virtual Farmacia IdFarmaciaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
        public virtual ICollection<ReservaMedicamento> ReservaMedicamentos { get; set; }
    }
}
