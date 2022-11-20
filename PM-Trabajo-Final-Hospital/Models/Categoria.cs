using System.ComponentModel.DataAnnotations;

namespace PM_Trabajo_Final_Hospital.Models
{
    public class Categoria
    {
        [Key]
        public int IdCateogira { get; set; }
        public string? Categorias { get; set; }

    }
}
