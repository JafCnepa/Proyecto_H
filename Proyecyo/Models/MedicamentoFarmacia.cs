using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecyo.Models
{
    public class MedicamentoFarmacia
    {

        [ForeignKey("Farmacia")]
        public int IdFarmacia { get; set; }

        [ForeignKey("Usuaruio")]
        public int IdUsuario { get; set; }

        public string? NombreCompletoUsuario { get; set; }
        public string? NombreFarmacia { get; set; }

        public Farmacia Farmacia { get; set; }
        public Usuario Usuario { get; set; }

    }
}
