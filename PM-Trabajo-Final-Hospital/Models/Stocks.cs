using System.ComponentModel.DataAnnotations;

namespace PM_Trabajo_Final_Hospital.Models
{
    public class Stocks
    {
        [Key]
        public int IdStock { get; set; }
        
        public string? StockName { get; set; }
    }
}
