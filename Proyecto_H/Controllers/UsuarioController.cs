using Microsoft.AspNetCore.Mvc;
using Proyecto_H.Datos;
using Proyecto_H.Models;

namespace Proyecto_H.Controllers
{
    public class UsuarioController : Controller
    {
        public readonly ApplicationDbContext _context;  
        public UsuarioController(ApplicationDbContext dbContext)
        {
            _context = dbContext;

        }
        //Method to list the users in the panel
        public IActionResult User()
        {
            List<Usuarios> listUser = _context.Usuarios.ToList();
            return View(listUser);

        }

        //Reading...
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        //Validating User Data to be stored in azure
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Add(usuarios);    
                _context.SaveChanges();
                return RedirectToAction("Register");
            }
            return View();
        }

        //the edit method is created so that the user can modify its fields and Azure
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Usuarios usuarios)
        {
            if(ModelState.IsValid)
            {
                _context.Usuarios.Update(usuarios);
                _context.SaveChanges();
                return RedirectToAction(nameof(User));
            }
            return View(usuarios);

        }

        //the delete method by id
        [HttpDelete]
        public IActionResult Delete(int? id)
        {

            var usuarios = _context.Usuarios.FirstOrDefault(
                    u => u.id_usuario==id);
            _context.Usuarios.Remove(usuarios);
            _context.SaveChanges();
            return RedirectToAction("User");

        }
    }
    
}
