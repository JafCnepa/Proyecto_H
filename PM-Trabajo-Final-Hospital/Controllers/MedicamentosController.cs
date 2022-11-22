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
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Nombrecompletousuario");
            ViewData["IdFarmacia"] = new SelectList(_context.Farmacia, "IdFarmacia", "Nombre");
         
            return View();
        }

        // POST: Medicamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMedicamento,Nombre,Fecha,UsuarioId,IdFarmacia,IdStocks,Precio")] Medicamentos medicamentos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicamentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicamentos);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Nombrecompletousuario", medicamentos.UsuarioId);
       
            ViewData["IdFarmacia"] = new SelectList(_context.Farmacia, "IdFarmacia", "Nombre", medicamentos.IdFarmacia);
          
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
         
            ViewData["IdFarmacia"] = new SelectList(_context.Farmacia, "IdFarmacia", "Nombre", medicamentos.IdFarmacia);

            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Nombrecompletousuario", medicamentos.UsuarioId);

            return View(medicamentos);
        }

        // POST: Medicamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMedicamento,Nombre,Fecha,UsuarioId,IdFarmacia,Precio")] Medicamentos medicamentos)
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
      
            ViewData["IdFarmacia"] = new SelectList(_context.Farmacia, "IdFarmacia", "Nombre", medicamentos.IdFarmacia);

            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Nombrecompletousuario", medicamentos.UsuarioId);
        
            return View(medicamentos);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var medicamento = _context.Medicamentos.FirstOrDefault(c => c.IdMedicamento == id);
            _context.Medicamentos.Remove(medicamento);
            _context.SaveChanges(true);
            return RedirectToAction("Index");
        }
        private bool MedicamentosExists(int id)
        {
          return _context.Medicamentos.Any(e => e.IdMedicamento == id);
        }
    }
}
