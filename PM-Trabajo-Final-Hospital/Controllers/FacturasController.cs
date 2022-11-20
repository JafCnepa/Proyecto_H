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
    public class FacturasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FacturasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Facturas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Factura.Include(f => f.Medicamento);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Facturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Factura == null)
            {
                return NotFound();
            }

            var facturas = await _context.Factura
                .Include(f => f.Medicamento)
                .FirstOrDefaultAsync(m => m.IdFactura == id);
            if (facturas == null)
            {
                return NotFound();
            }

            return View(facturas);
        }

        // GET: Facturas/Create
        public IActionResult Create()
        {
            ViewData["IdMedicamento"] = new SelectList(_context.Medicamentos, "IdMedicamento", "Nombre");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Nombrecompletousuario");
            return View();
        }

        // POST: Facturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFactura,Nombre,Telefono,Total,Fecha,UsuarioId,IdMedicamento,IdDistrito")] Facturas facturas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facturas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMedicamento"] = new SelectList(_context.Medicamentos, "IdMedicamento", "Nombre", facturas.IdMedicamento);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Nombrecompletousuario", facturas.UsuarioId);
            return View(facturas);
        }

        // GET: Facturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Factura == null)
            {
                return NotFound();
            }

            var facturas = await _context.Factura.FindAsync(id);
            if (facturas == null)
            {
                return NotFound();
            }
            ViewData["IdMedicamento"] = new SelectList(_context.Medicamentos, "IdMedicamento", "Nombre", facturas.IdMedicamento);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuariosId", "Nombrecompletousuario", facturas.UsuarioId);
            return View(facturas);
        }

        // POST: Facturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFactura,Nombre,Telefono,Total,Fecha,UsuarioId,IdMedicamento,IdDistrito")] Facturas facturas)
        {
            if (id != facturas.IdFactura)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facturas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturasExists(facturas.IdFactura))
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
            ViewData["IdMedicamento"] = new SelectList(_context.Medicamentos, "IdMedicamento", "Nombre", facturas.IdMedicamento);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuariosId", "Nombrecompletousuario", facturas.UsuarioId);
            return View(facturas);
        }

        // GET: Facturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Factura == null)
            {
                return NotFound();
            }

            var facturas = await _context.Factura
                .Include(f => f.Medicamento)
                .FirstOrDefaultAsync(m => m.IdFactura == id);
            if (facturas == null)
            {
                return NotFound();
            }

            return View(facturas);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Factura == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Factura'  is null.");
            }
            var facturas = await _context.Factura.FindAsync(id);
            if (facturas != null)
            {
                _context.Factura.Remove(facturas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturasExists(int id)
        {
          return _context.Factura.Any(e => e.IdFactura == id);
        }
    }
}
