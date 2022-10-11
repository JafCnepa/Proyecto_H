using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        {        //Validando la collecion usuarios al listar
            List<Medico> listaMedicos = _context.Medicos.ToList();
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
                _context.Medicos.Add(medico);
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
            var medico = _context.Medicos.FirstOrDefault
                (m => m.id_medico == id);
            return View(medico);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Medico medico)
        {
            if (ModelState.IsValid)
            {
                _context.Medicos.Update(medico);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(medico);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var medico = _context.Medicos.FirstOrDefault(
                m => m.id_medico == id);
            _context.Medicos.Remove(medico);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
