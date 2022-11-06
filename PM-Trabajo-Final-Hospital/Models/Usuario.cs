using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PM_Trabajo_Final_Hospital.Models
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
        [Display(Name = "Nombre ")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]
        public string? Nombre { get; set; }
        [Display(Name = "Apellido ")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]
        public string? Apellido { get; set; }
        [Display(Name = "Dni")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]
        public string? Dni { get; set; }

        [Display(Name = "Ruc")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 9)]
        public string Ruc { get; set; }
        [Display(Name = "Descripcion ")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]
        public string? Descripcion { get; set; }
        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(20, ErrorMessage = "Longitud máxima 50", MinimumLength = 9)]
        public string? Telefono { get; set; }
        [Display(Name = "Direccion ")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]
        public string? Direccion { get; set; }
        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
      ErrorMessage = "Dirección de Correo electrónico incorrecta.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50")]
        [DataType(DataType.EmailAddress)]
        public string? Correo { get; set; }
        [Display(Name = "Usuario ")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]
        public string? Usuario1 { get; set; }
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud entre 8 y 20 caracteres.",
                     MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string? Clave { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
        public virtual ICollection<Medicamento> Medicamentos { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
