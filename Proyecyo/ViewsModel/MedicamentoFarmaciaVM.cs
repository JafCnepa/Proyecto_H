using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecyo.Models;

namespace Proyecyo.ViewsModel
{
    public class MedicamentoFarmaciaVM
    {
        public MedicamentoFarmacia MedicamentoFarmacia { get; set; }
        public Farmacia Farmacia { get; set; }
     
        public IEnumerable<MedicamentoFarmacia> ListaMedicamentoFarmacia { get; set; }
        public IEnumerable<SelectListItem> Listas { get; set; }
    }
}
