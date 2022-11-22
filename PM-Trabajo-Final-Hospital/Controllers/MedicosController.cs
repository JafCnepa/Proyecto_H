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
    public class MedicosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedicosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Medicos
        public async Task<IActionResult> Index()
        {

            var arzobispoContext = _context.Medicos.Include(m => m.Certificacion).Include(m => m.Colegiado).Include(m => m.Usuario);
            return View(await arzobispoContext.ToListAsync());
        }

        // GET: Medicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Medicos == null)
            {
                return NotFound();
            }

            var medico = await _context.Medicos
              .Include(m => m.Certificacion)
              .Include(m => m.Colegiado)

              .Include(m => m.Usuario)
              .FirstOrDefaultAsync(m => m.IdMedico == id);
            if (medico == null)
            {
                return NotFound();
            }

            return View(medico);
        }

        // GET: Medicos/Create
        public IActionResult Create()
        {

            ViewData["IdCertificacion"] = new SelectList(_context.Certificacions, "IdCertificacion", "Certificaciones");
            ViewData["IdColegiado"] = new SelectList(_context.Colegiados, "IdColegiado", "Colegiados");

            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Nombrecompletousuario");
            return View();
        }

        // POST: Medicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMedico,Nombrecompletomedico,Dnimedico,Fecha,Cedula,Salon,Foto,Especialidad,UsuarioId,IdColegiado,IdCertificacion")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCertificacion"] = new SelectList(_context.Certificacions, "IdCertificacion", "Certificaciones", medico.IdCertificacion);
            ViewData["IdColegiado"] = new SelectList(_context.Colegiados, "IdColegiado", "Colegiados", medico.IdColegiado);

            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Nombrecompletousuario", medico.UsuarioId);
            return View(medico);
        }

        // GET: Medicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Medicos == null)
            {
                return NotFound();
            }

            var medico = await _context.Medicos.FindAsync(id);
            if (medico == null)
            {
                return NotFound();
            }

            ViewData["IdCertificacion"] = new SelectList(_context.Certificacions, "IdCertificacion", "Certificaciones");
            ViewData["IdColegiado"] = new SelectList(_context.Colegiados, "IdColegiado", "Colegiados");

            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Nombrecompletousuario");
            return View(medico);
        }

        // POST: Medicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMedico,Nombrecompletomedico,Dnimedico,Fecha,Cedula,Salon,Foto,Especialidad,UsuarioId,IdColegiado,IdCertificacion")] Medico medico)
        {
            if (id != medico.IdMedico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicoExists(medico.IdMedico))
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

            ViewData["IdCertificacion"] = new SelectList(_context.Certificacions, "IdCertificacion", "Certificaciones", medico.IdCertificacion);
            ViewData["IdColegiado"] = new SelectList(_context.Colegiados, "IdColegiado", "Colegiados", medico.IdColegiado);

            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Nombrecompletousuario", medico.UsuarioId);
            return View(medico);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var medico = _context.Medicos.FirstOrDefault(c => c.IdMedico == id);
            _context.Medicos.Remove(medico);
            _context.SaveChanges(true);
            return RedirectToAction("Index");
        }


        private bool MedicoExists(int id)
        {
          return _context.Medicos.Any(e => e.IdMedico == id);
        }
    }
}
