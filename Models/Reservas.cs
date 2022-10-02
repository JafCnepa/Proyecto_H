using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class Reservas
    {
        [Key]
        public int id_reserva { get; set; }
        public int id_medico { get; set; }
        public int id_productos { get; set; }
        public virtual ICollection<Medico> Medico { get; set; } 
        public virtual ICollection<Productos> Productos { get; set; }
                

    }
}
