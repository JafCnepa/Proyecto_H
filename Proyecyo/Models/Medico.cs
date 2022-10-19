using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecyo.Models
{
    public partial class Medico
    {
      

        public Medico()
        {
           
             
        ReservaCita = new HashSet<ReservaCitum>();
         
        }
        [Key]
        public int IdMedico { get; set; }
        [Required, StringLength(20, MinimumLength = 8)]
        public string? Nombre { get; set; }
        [Required, StringLength(20, MinimumLength = 8)]
        public string? Apellido { get; set; }
        [Required, StringLength(20, MinimumLength = 8)]
        public string? Especialidad { get; set; }
        [Required, StringLength(8, MinimumLength = 8)]
        public string? Dni { get; set; }
        [Required, StringLength(20, MinimumLength = 1)]
        public string? Certificado { get; set; }
        [ForeignKey("IdUsuario")]
        public int IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; } 
      
        public virtual ICollection<ReservaCitum> ReservaCita { get; set; }
    
 




    }
}
