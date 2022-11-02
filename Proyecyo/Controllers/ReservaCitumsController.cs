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
    public class ReservaCitumsController : Controller
    {
        private readonly HospitalContext _context;

        public ReservaCitumsController(HospitalContext context)
        {
            _context = context;
        }

        // GET: ReservaCitums
        public async Task<IActionResult> Index()
        {
            var hospitalContext = _context.ReservaCita.Include(r => r.IdMedicoNavigation);
            return View(await hospitalContext.ToListAsync());
        }

        // GET: ReservaCitums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ReservaCita == null)
            {
                return NotFound();
            }

            var reservaCitum = await _context.ReservaCita
                .Include(r => r.IdMedicoNavigation)
                .FirstOrDefaultAsync(m => m.IdCita == id);
            if (reservaCitum == null)
            {
                return NotFound();
            }

            return View(reservaCitum);
        }

        // GET: ReservaCitums/Create
        public IActionResult Create()
        {
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "NombrecompletoDoctor");
            return View();
        }

        // POST: ReservaCitums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCita,IdMedico")] ReservaCitum reservaCitum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservaCitum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "NombrecompletoDoctor", reservaCitum.IdMedico);
            return View(reservaCitum);
        }

        // GET: ReservaCitums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ReservaCita == null)
            {
                return NotFound();
            }

            var reservaCitum = await _context.ReservaCita.FindAsync(id);
            if (reservaCitum == null)
            {
                return NotFound();
            }
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "NombrecompletoDoctor", reservaCitum.IdMedico);
            return View(reservaCitum);
        }

        // POST: ReservaCitums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCita,IdMedico")] ReservaCitum reservaCitum)
        {
            if (id != reservaCitum.IdCita)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservaCitum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaCitumExists(reservaCitum.IdCita))
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
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "NombrecompletoDoctor", reservaCitum.IdMedico);
            return View(reservaCitum);
        }

        // GET: ReservaCitums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ReservaCita == null)
            {
                return NotFound();
            }

            var reservaCitum = await _context.ReservaCita
                .Include(r => r.IdMedicoNavigation)
                .FirstOrDefaultAsync(m => m.IdCita == id);
            if (reservaCitum == null)
            {
                return NotFound();
            }

            return View(reservaCitum);
        }

        // POST: ReservaCitums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ReservaCita == null)
            {
                return Problem("Entity set 'HospitalContext.ReservaCita'  is null.");
            }
            var reservaCitum = await _context.ReservaCita.FindAsync(id);
            if (reservaCitum != null)
            {
                _context.ReservaCita.Remove(reservaCitum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaCitumExists(int id)
        {
          return _context.ReservaCita.Any(e => e.IdCita == id);
        }
    }
}
