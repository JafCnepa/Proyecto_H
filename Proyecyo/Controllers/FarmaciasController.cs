
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using Proyecyo.Models;

namespace Proyecyo.Controllers
{
    public class FarmaciasController : Controller
    {
        private readonly HospitalContext _context;

        public FarmaciasController(HospitalContext context)
        {
            _context = context;
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
                (f => f.IdFarmacia == id);
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
                f => f.IdFarmacia == id);
            _context.Farmacias.Remove(farmacia);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
