using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PM_Trabajo_Final_Hospital.Models
{
    public class Facturas
    {

        [Key]
        public int IdFactura { get; set; }
        [Display(Name = "Nombre ")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 8)]
        public string? Nombre { get; set; }
        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(20, ErrorMessage = "Longitud máxima 50", MinimumLength = 9)]
        public string? Telefono { get; set; }
        [Display(Name = "Total")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(1000, ErrorMessage = "Longitud máxima 50", MinimumLength = 1)]
        public string? Total { get; set; }
        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "Este campo requiere fecha")]
        [DataType(DataType.Date)]
        public DateTime? Fecha { get; set; }
        [ForeignKey("Usuarios")]
        public int UsuarioId { get; set; }
        [ForeignKey("Medicamento")]
        public int IdMedicamento { get; set; }
        [ForeignKey("Distrito")]
        public int IdDistrito { get; set; }


        public virtual Distrito Distrtios { get; set; }
        public virtual Medicamentos Medicamento { get; set; }
        public virtual Usuario Usuario { get; set; }
    }

}
