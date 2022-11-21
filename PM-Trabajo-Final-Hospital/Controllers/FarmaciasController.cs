using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PM_Trabajo_Final_Hospital.Datos;
using PM_Trabajo_Final_Hospital.Models;

namespace PM_Trabajo_Final_Hospital.Controllers
{
    public class FarmaciasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FarmaciasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Farmacias
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Farmacia.Include(f => f.Departamento).Include(f => f.Distrito);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Farmacias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Farmacia == null)
            {
                return NotFound();
            }

            var farmacias = await _context.Farmacia
                .Include(f => f.Departamento)
                .Include(f => f.Distrito)
                .FirstOrDefaultAsync(m => m.IdFarmacia == id);
            if (farmacias == null)
            {
                return NotFound();
            }

            return View(farmacias);
        }

        // GET: Farmacias/Create
        public IActionResult Create()
        {
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "IdDepartamento", "IdDepartamento");
            ViewData["IdDistrito"] = new SelectList(_context.Distritos, "IdDistrito", "IdDistrito");
            return View();
        }

        // POST: Farmacias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFarmacia,Nombre,IdDepartamento,IdDistrito,Avenida")] Farmacias farmacias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(farmacias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "IdDepartamento", "IdDepartamento", farmacias.IdDepartamento);
            ViewData["IdDistrito"] = new SelectList(_context.Distritos, "IdDistrito", "IdDistrito", farmacias.IdDistrito);
            return View(farmacias);
        }

        // GET: Farmacias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Farmacia == null)
            {
                return NotFound();
            }

            var farmacias = await _context.Farmacia.FindAsync(id);
            if (farmacias == null)
            {
                return NotFound();
            }
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "IdDepartamento", "IdDepartamento", farmacias.IdDepartamento);
            ViewData["IdDistrito"] = new SelectList(_context.Distritos, "IdDistrito", "IdDistrito", farmacias.IdDistrito);
            return View(farmacias);
        }

        // POST: Farmacias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFarmacia,Nombre,IdDepartamento,IdDistrito,Avenida")] Farmacias farmacias)
        {
            if (id != farmacias.IdFarmacia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(farmacias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FarmaciasExists(farmacias.IdFarmacia))
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
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "IdDepartamento", "IdDepartamento", farmacias.IdDepartamento);
            ViewData["IdDistrito"] = new SelectList(_context.Distritos, "IdDistrito", "IdDistrito", farmacias.IdDistrito);
            return View(farmacias);
        }

        // GET: Farmacias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Farmacia == null)
            {
                return NotFound();
            }

            var farmacias = await _context.Farmacia
                .Include(f => f.Departamento)
                .Include(f => f.Distrito)
                .FirstOrDefaultAsync(m => m.IdFarmacia == id);
            if (farmacias == null)
            {
                return NotFound();
            }

            return View(farmacias);
        }

        // POST: Farmacias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Farmacia == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Farmacia'  is null.");
            }
            var farmacias = await _context.Farmacia.FindAsync(id);
            if (farmacias != null)
            {
                _context.Farmacia.Remove(farmacias);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FarmaciasExists(int id)
        {
          return _context.Farmacia.Any(e => e.IdFarmacia == id);
        }
    }
}
