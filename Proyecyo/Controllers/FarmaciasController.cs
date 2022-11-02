using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        // GET: Farmacias
        public async Task<IActionResult> Index()
        {
              return View(await _context.Farmacias.ToListAsync());
        }

        // GET: Farmacias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Farmacias == null)
            {
                return NotFound();
            }

            var farmacia = await _context.Farmacias
                .FirstOrDefaultAsync(m => m.IdFarmacia == id);
            if (farmacia == null)
            {
                return NotFound();
            }

            return View(farmacia);
        }

        // GET: Farmacias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Farmacias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFarmacia,Nombrefarmacia,Pais,Departamento,Distrito")] Farmacia farmacia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(farmacia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(farmacia);
        }

        // GET: Farmacias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Farmacias == null)
            {
                return NotFound();
            }

            var farmacia = await _context.Farmacias.FindAsync(id);
            if (farmacia == null)
            {
                return NotFound();
            }
            return View(farmacia);
        }

        // POST: Farmacias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFarmacia,Nombrefarmacia,Pais,Departamento,Distrito")] Farmacia farmacia)
        {
            if (id != farmacia.IdFarmacia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(farmacia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FarmaciaExists(farmacia.IdFarmacia))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(farmacia);
        }

        // GET: Farmacias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Farmacias == null)
            {
                return NotFound();
            }

            var farmacia = await _context.Farmacias
                .FirstOrDefaultAsync(m => m.IdFarmacia == id);
            if (farmacia == null)
            {
                return NotFound();
            }

            return View(farmacia);
        }

        // POST: Farmacias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Farmacias == null)
            {
                return Problem("Entity set 'HospitalContext.Farmacias'  is null.");
            }
            var farmacia = await _context.Farmacias.FindAsync(id);
            if (farmacia != null)
            {
                _context.Farmacias.Remove(farmacia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FarmaciaExists(int id)
        {
          return _context.Farmacias.Any(e => e.IdFarmacia == id);
        }
    }
}
