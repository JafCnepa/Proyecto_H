using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PM_Trabajo_Final_Hospital.Models
{
    public class Medico
    {
        [Key]
        public int IdMedico { get; set; }
        [Display(Name = "Nombre  Completo")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]
        public string? Nombrecompletomedico { get; set; }
        [Display(Name = "Dni")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(8, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]
        public string? Dnimedico { get; set; }
        [Display(Name = "Fecha Cita")]
        [Required(ErrorMessage = "Este campo requiere fecha de la cita")]
        [DataType(DataType.Date)]
        public DateTime? Fecha { get; set; }
        [Display(Name = "Cedula")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(12, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]
        public string? Cedula { get; set; }
        [Display(Name = "Habitacion")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]

        public string? Salon { get; set; }
        [NotMapped]
      
        public  IFormFile toBase64 { get; set; }
        public string? Foto { get; set; }
        

        [Display(Name = "Nombre De La Especialidad")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]
        public string? Especialidad { get; set; }
        public int UsuarioId { get; set; }

      

      
        public int IdColegiado { get; set; }
    
        public int IdCertificacion { get; set; }

       
       
        public   virtual Certificacion Certificacion { get; set; }
        public virtual Colegiado Colegiado { get; set; }
 
        public   virtual Usuario Usuario { get; set; }
    }
}
