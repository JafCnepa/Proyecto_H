using System;

using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using Proyecyo.Models;

namespace Proyecyo.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly HospitalContext _context;

        public UsuariosController(HospitalContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            List<Usuario> listaUsuarios = _context.Usuarios.ToList();
            return View(listaUsuarios);

        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Add(usuario);
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
            var usuario = _context.Usuarios.FirstOrDefault
                (u => u.IdUsuario == id);
            return View(usuario);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Update(usuario);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(
                u => u.IdUsuario == id);
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
