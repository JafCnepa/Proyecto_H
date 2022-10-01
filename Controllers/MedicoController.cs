using Microsoft.AspNetCore.Mvc;
using Proyecto.Datos;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class MedicoController : Controller
    {
        public readonly ApplicationDbContext _context;
        public MedicoController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        //Method to list the doctors in the panel
        public IActionResult Especialistas()
        {
            List<Medico> listDoctors = _context.Medico.ToList();
            return View(listDoctors);

        }

        //Reading...
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        //Validating Doctors Data to be stored in mysql
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Medico medico)
        {
            if (ModelState.IsValid)
            {
                _context.Medico.Add(medico);
                _context.SaveChanges();
                return RedirectToAction("Especialistas");
            }
            return View();
        }
        //the edit method is created so that the doctors can modify its fields and mysql
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Medico medico)
        {
            if (ModelState.IsValid)
            {
                _context.Medico.Update(medico);
                _context.SaveChanges();
                return RedirectToAction(nameof(Especialistas));
            }
            return View(medico);

        }



        //the delete method by id
        [HttpDelete]
        public IActionResult Delete(int? id)
        {

            var medico = _context.Medico.FirstOrDefault(
                    d => d.id_medico == id);
            _context.Medico.Remove(medico);
            _context.SaveChanges();
            return RedirectToAction("Especialistas");

        }

    }
}
