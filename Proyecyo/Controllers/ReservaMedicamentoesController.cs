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
    public class ReservaMedicamentoesController : Controller
    {
        private readonly HospitalContext _context;

        public ReservaMedicamentoesController(HospitalContext context)
        {
            _context = context;
        }

        // GET: ReservaMedicamentoes
        public async Task<IActionResult> Index()
        {
            var hospitalContext = _context.ReservaMedicamentos.Include(r => r.IdMedicamentoNavigation);
            return View(await hospitalContext.ToListAsync());
        }

        // GET: ReservaMedicamentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ReservaMedicamentos == null)
            {
                return NotFound();
            }

            var reservaMedicamento = await _context.ReservaMedicamentos
                .Include(r => r.IdMedicamentoNavigation)
                .FirstOrDefaultAsync(m => m.IdReservamedicamento == id);
            if (reservaMedicamento == null)
            {
                return NotFound();
            }

            return View(reservaMedicamento);
        }

        // GET: ReservaMedicamentoes/Create
        public IActionResult Create()
        {
            ViewData["IdMedicamento"] = new SelectList(_context.Medicamentos, "IdMedicamento", "Categoria");
            return View();
        }

        // POST: ReservaMedicamentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReservamedicamento,IdMedicamento,Stock")] ReservaMedicamento reservaMedicamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservaMedicamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMedicamento"] = new SelectList(_context.Medicamentos, "IdMedicamento", "Categoria", reservaMedicamento.IdMedicamento);
            return View(reservaMedicamento);
        }

        // GET: ReservaMedicamentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ReservaMedicamentos == null)
            {
                return NotFound();
            }

            var reservaMedicamento = await _context.ReservaMedicamentos.FindAsync(id);
            if (reservaMedicamento == null)
            {
                return NotFound();
            }
            ViewData["IdMedicamento"] = new SelectList(_context.Medicamentos, "IdMedicamento", "Categoria", reservaMedicamento.IdMedicamento);
            return View(reservaMedicamento);
        }

        // POST: ReservaMedicamentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReservamedicamento,IdMedicamento,Stock")] ReservaMedicamento reservaMedicamento)
        {
            if (id != reservaMedicamento.IdReservamedicamento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservaMedicamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaMedicamentoExists(reservaMedicamento.IdReservamedicamento))
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
            ViewData["IdMedicamento"] = new SelectList(_context.Medicamentos, "IdMedicamento", "Categoria", reservaMedicamento.IdMedicamento);
            return View(reservaMedicamento);
        }

        // GET: ReservaMedicamentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ReservaMedicamentos == null)
            {
                return NotFound();
            }

            var reservaMedicamento = await _context.ReservaMedicamentos
                .Include(r => r.IdMedicamentoNavigation)
                .FirstOrDefaultAsync(m => m.IdReservamedicamento == id);
            if (reservaMedicamento == null)
            {
                return NotFound();
            }

            return View(reservaMedicamento);
        }

        // POST: ReservaMedicamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ReservaMedicamentos == null)
            {
                return Problem("Entity set 'HospitalContext.ReservaMedicamentos'  is null.");
            }
            var reservaMedicamento = await _context.ReservaMedicamentos.FindAsync(id);
            if (reservaMedicamento != null)
            {
                _context.ReservaMedicamentos.Remove(reservaMedicamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaMedicamentoExists(int id)
        {
          return _context.ReservaMedicamentos.Any(e => e.IdReservamedicamento == id);
        }
    }
}
