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
    public class MedicosController : Controller
    {
        private readonly HospitalContext _context;

        public MedicosController(HospitalContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Medico> listaMedicos = _context.Medicos.ToList();
            return View(listaMedicos);

        }
        [HttpGet]


        [HttpGet]
        public IActionResult Create()
        {
            PacientesVM paciente = new PacientesVM();
            paciente.ListaUsuarios = _context.Usuarios.Select(i => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = i.NombrecompletoUsuario,
                Value = i.IdUsuario.ToString()
            });
            return View(paciente);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Medico medico)
        {
            if (ModelState.IsValid)
            {
                _context.Medicos.Add(medico);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            PacientesVM paciente = new PacientesVM();
            paciente.ListaUsuarios = _context.Usuarios.Select(i => new SelectListItem
            {
                Text = i.NombrecompletoUsuario,
                Value = i.IdUsuario.ToString()
            });
            return View(paciente);
        }
        [HttpGet]
      

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View();
            }
            PacientesVM paciente = new PacientesVM();
            paciente.ListaUsuarios = _context.Usuarios.Select(i => new SelectListItem
            {
                Text = i.NombrecompletoUsuario,
                Value = i.IdUsuario.ToString()
            });
            paciente.Medico = _context.Medicos.FirstOrDefault(c => c.IdMedico == id);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PacientesVM paciente)
        {
            if (paciente.Medico.IdMedico == 0)
            {
                return View(paciente.Medico);
            }
            else
            {
                _context.Medicos.Update(paciente.Medico);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var medico = _context.Medicos.FirstOrDefault(m => m.IdMedico == id);
            _context.Medicos.Remove(medico);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}