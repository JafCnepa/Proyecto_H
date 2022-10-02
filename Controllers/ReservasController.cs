
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using Proyecto.Datos;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class ReservasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservasController(ApplicationDbContext context)
        {
            _context = context;
        }

        
                  
        
    }
}
