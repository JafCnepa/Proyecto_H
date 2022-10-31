using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecyo.Models;

namespace Proyecyo.Models
{
    public class PacientesVM
    {

        public Medico Medico { get; set; }
        public IEnumerable<SelectListItem> ListaUsuarios { get; set; }
    }
}
