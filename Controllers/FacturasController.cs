
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using Proyecto.Datos;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class FacturasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FacturasController(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
