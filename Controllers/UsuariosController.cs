using Microsoft.AspNetCore.Mvc;
using Proyecto.Datos;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class UsuariosController : Controller
    {
        public readonly ApplicationDbContext _context;
        public UsuariosController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        //Method to list the doctors in the panel
        public IActionResult Index()
        {
            List<Usuarios> listUsers = _context.Usuario.ToList();
            return View(listUsers);

        }
        //Reading...
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        //Validating Doctors Data to be stored in mysql
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuario.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        //the edit method is created so that the doctors can modify its fields and mysql
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View();
            }
            //lambda
            var usuario = _context.Usuario.FirstOrDefault
                (c => c.id_usuario == id);
            return View(usuario);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuario.Update(usuario);
                _context.SaveChanges();
                //redireccionar al index
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }
        //the delete method by id
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var usuario = _context.Usuario.FirstOrDefault(
                c => c.id_usuario == id);
            _context.Usuario.Remove(usuario);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
