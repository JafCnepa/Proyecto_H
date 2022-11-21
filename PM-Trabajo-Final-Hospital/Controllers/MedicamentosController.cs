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
    public class MedicamentosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedicamentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Medicamentos
        public IActionResult Index()
        {
            List<Medicamentos> listaMedicamentos = _context.Medicamentos.ToList();
            return View(listaMedicamentos);
        }

        // GET: Medicamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Medicamentos == null)
            {
                return NotFound();
            }

            var medicamentos = await _context.Medicamentos
                .FirstOrDefaultAsync(m => m.IdMedicamento == id);
            if (medicamentos == null)
            {
                return NotFound();
            }

            return View(medicamentos);
        }

        // GET: Medicamentos/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuariosId", "Nombrecompletousuario");
            ViewData["Idcategoria"] = new SelectList(_context.Categorias, "IdCategoria", "Categorias");
            ViewData["IdFarmacia"] = new SelectList(_context.Farmacia, "IdFarmacia", "Farmacia");
            ViewData["IdStocks"] = new SelectList(_context.Stocks, "IdStocks", "StockName");
            return View();
        }

        // POST: Medicamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMedicamento,Nombre,Fecha,UsuarioId,IdCategoria,IdFarmacia,IdStocks,Precio")] Medicamentos medicamentos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicamentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicamentos);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuariosId", "Nombrecompletousuario", medicamentos.UsuarioId);
            ViewData["IdCategoria"] = new SelectList(_context.Categorias, "IdCategoria", "Categorias", medicamentos.IdCategoria);
            ViewData["IdFarmacia"] = new SelectList(_context.Farmacia, "IdFarmacia", "Farmacia", medicamentos.IdFarmacia);
            ViewData["IdStocks"] = new SelectList(_context.Stocks, "IdStocks", "StockName", medicamentos.IdStocks);
        }

        // GET: Medicamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Medicamentos == null)
            {
                return NotFound();
            }

            var medicamentos = await _context.Medicamentos.FindAsync(id);
            if (medicamentos == null)
            {
                return NotFound();
            }
            ViewData["IdCategoria"] = new SelectList(_context.Categorias, "IdCategoria", "Categorias",  medicamentos.IdCategoria);
            ViewData["IdFarmacia"] = new SelectList(_context.Farmacia, "IdFarmacia", "Nombre", medicamentos.IdFarmacia);

            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "IdUsuario", "Nombrecompletousuario", medicamentos.UsuarioId);
            ViewData["IdStocks"] = new SelectList(_context.Stocks, "IdStocks", "StockName", medicamentos.IdStocks);
            return View(medicamentos);
        }

        // POST: Medicamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMedicamento,Nombre,Fecha,UsuarioId,IdCategoria,IdFarmacia,IdStocks,Precio")] Medicamentos medicamentos)
        {
            if (id != medicamentos.IdMedicamento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicamentos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicamentosExists(medicamentos.IdMedicamento))
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
            ViewData["IdCategoria"] = new SelectList(_context.Categorias, "IdCategoria", "Categorias", medicamentos.IdCategoria);
            ViewData["IdFarmacia"] = new SelectList(_context.Farmacia, "IdFarmacia", "Nombre", medicamentos.IdFarmacia);

            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "IdUsuario", "Nombrecompletousuario", medicamentos.UsuarioId);
            ViewData["IdStocks"] = new SelectList(_context.Stocks, "IdStocks", "StockName", medicamentos.IdStocks);
            return View(medicamentos);
        }

        // GET: Medicamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Medicamentos == null)
            {
                return NotFound();
            }

            var medicamentos = await _context.Medicamentos
                 .Include(m => m.IdFarmacia)
                 .Include(m => m.IdCategoria)
                 .Include(m => m.UsuarioId)
                 .Include(m=> m.IdStocks)
               
                .FirstOrDefaultAsync(m => m.IdMedicamento == id);
            if (medicamentos == null)
            {
                return NotFound();
            }

            return View(medicamentos);
        }

        // POST: Medicamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Medicamentos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Medicamentos'  is null.");
            }
            var medicamentos = await _context.Medicamentos.FindAsync(id);
            if (medicamentos != null)
            {
                _context.Medicamentos.Remove(medicamentos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicamentosExists(int id)
        {
          return _context.Medicamentos.Any(e => e.IdMedicamento == id);
        }
    }
}
