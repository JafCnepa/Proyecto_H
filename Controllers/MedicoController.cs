using Microsoft.AspNetCore.Mvc;
using Proyecto.Datos;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class MedicoController: Controller
    {
        public readonly ApplicationDbContext _context;
        public MedicoController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public IActionResult Index()
        {
            List<Medico> listaMedicos = _context.Medico.ToList();
            return View(listaMedicos);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Medico medico)
        {
            if (ModelState.IsValid)
            {
                _context.Medico.Add(medico);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View();
            }
            var medico = _context.Medico.FirstOrDefault
                (m => m.id_medico == id);
            return View(medico);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Medico medico)
        {
            if (ModelState.IsValid)
            {
                _context.Medico.Update(medico);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(medico);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var medico = _context.Medico.FirstOrDefault(
                m => m.id_medico == id);
            _context.Medico.Remove(medico);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
