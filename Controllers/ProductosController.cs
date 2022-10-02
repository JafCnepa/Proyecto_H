
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto.Datos;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Method to list the Products in the panel
        public IActionResult Product()
        {
            List<Productos> listProducts = _context.Productos.ToList();
            return View(listProducts);

        }

        //Reading...
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        //Validating Products Data to be stored in mysql
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Productos productos)
        {
            if (ModelState.IsValid)
            {
                _context.Productos.Add(productos);
                _context.SaveChanges();
                return RedirectToAction("Product");
            }
            return View();
        }
        //the edit method is created so that the products can modify its fields and mysql
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Productos productos)
        {
            if (ModelState.IsValid)
            {
                _context.Productos.Update(productos);
                _context.SaveChanges();
                return RedirectToAction(nameof(Product));
            }
            return View(productos);

        }


        //the delete method by id
        [HttpDelete]
        public IActionResult Delete(int? id)
        {

            var productos = _context.Productos.FirstOrDefault(
                    p => p.id_productos == id);
            _context.Productos.Remove(productos);
            _context.SaveChanges();
            return RedirectToAction("Product");

        }
    }
}
