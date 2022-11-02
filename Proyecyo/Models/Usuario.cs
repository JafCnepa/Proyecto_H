﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecyo.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Facturas = new HashSet<Factura>();
            Medicamentos = new HashSet<Medicamento>();
            Medicos = new HashSet<Medico>();
            ReservaCita = new HashSet<ReservaCitum>();
        }

        [Key]
        public int IdUsuario { get; set; }
        [Display(Name = "Nombre Completo ")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]
        public string? Nombrecompletousuario { get; set; }

        [Display(Name = "Dni")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]
        public string? Dniusuario { get; set; }

        [Display(Name = "Ruc")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 9)]
        public string? Rucusuario { get; set; }

        [Display(Name = "Celular")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(20, ErrorMessage = "Longitud máxima 50", MinimumLength = 9)]
        public string? Celularusuario { get; set; }

        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
      ErrorMessage = "Dirección de Correo electrónico incorrecta.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50")]
        [DataType(DataType.EmailAddress)]
        public string? Correousuario { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        [Required(ErrorMessage = "Este campo requiere fecha nacimiento")]
        [DataType(DataType.Date)]
    
        public DateTime? FechaNacimiento { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud entre 8 y 20 caracteres.",
                     MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string? Clave { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
        public virtual ICollection<Medicamento> Medicamentos { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual ICollection<ReservaCitum> ReservaCita { get; set; }
    }
}
