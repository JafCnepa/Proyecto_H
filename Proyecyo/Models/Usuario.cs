using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Proyecyo.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Facturas = new HashSet<Factura>();
            Medicamentos = new HashSet<Medicamento>();
            Medicos = new HashSet<Medico>();
        }
        [Key]
        public int IdUsuario { get; set; }
        [Required, StringLength(20, MinimumLength = 8)]
        public string? Nombre { get; set; }
        [Required, StringLength(20, MinimumLength = 8)]
        public string? Apellido { get; set; }
        [Required, StringLength(8, MinimumLength = 8)]
        public string? Dni { get; set; }
        [Required, StringLength(15, MinimumLength = 8)]
        public string? Ruc { get; set; }
        [Required, StringLength(20, MinimumLength = 9)]
        public string? Celular { get; set; }
        [Required(ErrorMessage = "Correo es requerido")]
        public string? Correo { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "fecha de nacimiento es requerido")]
        public DateTime? FechaNacimiento { get; set; }
        [Required, PasswordPropertyText]
        public string? Clave { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
        public virtual ICollection<Medicamento> Medicamentos { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
