using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PM_Trabajo_Final_Hospital.Models
{
    public class Medicamentos
    {
        [Key]
        public int IdMedicamento { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 4)]
        public string Nombre { get; set; }
        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "Este campo requiere fecha")]
        [DataType(DataType.Date)]
        public DateTime? Fecha { get; set; }
        [ForeignKey("Usuarios")]
        public int UsuarioId { get; set; }
        [ForeignKey("Categorias")]

        public int IdCategoria { get; set; }
   
     
        [ForeignKey("Farmacias")]
        public int IdFarmacia { get; set; }
        public string? Precio { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual Farmacias Farmacia { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
