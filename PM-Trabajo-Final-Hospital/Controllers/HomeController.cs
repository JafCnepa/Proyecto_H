using Microsoft.AspNetCore.Mvc;
using PM_Trabajo_Final_Hospital.Models;
using System.Diagnostics;

namespace PM_Trabajo_Final_Hospital.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult CambiarClave()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Medicos()
        {
            return View();
        }

        public IActionResult MedicosAdd()
        {
            return View();
        }

        public IActionResult MedicosEdit()
        {
            return View();
        }

        public IActionResult MedicosDetail()
        {
            return View();
        }

        public IActionResult Farmacias()
        {
            return View();
        }

        public IActionResult FarmaciasAdd()
        {
            return View();
        }

        public IActionResult FarmaciasEdit()
        {
            return View();
        }

        public IActionResult FarmaciasDetail()
        {
            return View();
        }

        public IActionResult Productos()
        {
            return View();
        }

        public IActionResult ProductosAdd()
        {
            return View();
        }

        public IActionResult ProductosEdit()
        {
            return View();
        }

        public IActionResult ProductosDetail()
        {
            return View();
        }

        public IActionResult Facturas()
        {
            return View();
        }

        public IActionResult FacturasAdd()
        {
            return View();
        }

        public IActionResult FacturasEdit()
        {
            return View();
        }

        public IActionResult FacturasDetail()
        {
            return View();
        }
        public IActionResult Usuarios()
        {
            return View();
        }

        public IActionResult UsuariosAdd()
        {
            return View();
        }

        public IActionResult UsuariosEdit()
        {
            return View();
        }
        public IActionResult UsuariosDetail()
        {
            return View();
        }

        public IActionResult Perfil()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}