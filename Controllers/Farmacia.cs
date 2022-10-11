using Microsoft.AspNetCore.Mvc;
using Proyecto.Datos;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class FarmaciaController: Controller
    {
        public readonly ApplicationDbContext _context;
        public FarmaciaController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public IActionResult Index()
        {
            List<Farmacia> listaFarmacias = _context.Farmacias.ToList();
            return View(listaFarmacias);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Farmacia farmacia)
        {
            if (ModelState.IsValid)
            {
                _context.Farmacias.Add(farmacia);
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
            var farmacia = _context.Farmacias.FirstOrDefault
                (f => f.id_farmacia == id);
            return View(farmacia);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Farmacia farmacia)
        {
            if (ModelState.IsValid)
            {
                _context.Farmacias.Update(farmacia);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(farmacia);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var farmacia = _context.Farmacias.FirstOrDefault(
                f => f.id_farmacia == id);
            _context.Farmacias.Remove(farmacia);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
