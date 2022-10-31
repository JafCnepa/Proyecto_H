using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecyo.Models;
using Proyecyo.ViewsModel;

namespace Proyecyo.Controllers
{
    public class MedicamentoController : Controller
    {
        private readonly HospitalContext _context;

        public MedicamentoController(HospitalContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Medicamento> listaMedicamento = _context.Medicamentos.ToList();
            return View(listaMedicamento);

        }
        [HttpGet]
        public IActionResult Create(int id)
        {
            MedicamentoFarmaciaVM medicamento = new MedicamentoFarmaciaVM();
            {
                ListaMedicamentoFarmacia = _context.MedicamentoFarmacia.Include(u => u.Usuario).
                Include(f => f.Farmacia).Where(f => f.IdFarmacia == id);
                MedicamentoFarmacia = new MedicamentoFarmacia();
                {
                    IdFarmacia = id;
                };
                Farmacia = _context.Farmacias.FirstOrDefault(f => f.IdFarmacia == id);
            };
            List<int> listaTem = medicamento.ListaMedicamentoFarmacia.
                Select(u => u.IdUsuario).ToList();
       
            var list = _context.Usuarios.Where(u => !listaTem.
            Contains(u.IdUsuario)).ToList();
            //Crear lista de etiquetas para el dropdown
            medicamento.Listas = list.Select(u => new SelectListItem
            {
                Text = u.NombrecompletoUsuario,
                Value = u.IdUsuario.ToString()
            });

            return View(medicamento);
        }


    }
}
