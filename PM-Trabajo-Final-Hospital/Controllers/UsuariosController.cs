using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Mvc.Rendering;
using PM_Trabajo_Final_Hospital.Models;
using PM_Trabajo_Final_Hospital.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Microsoft.AspNetCore.Authentication;

using System.Security.Claims;
namespace PM_Trabajo_Final_Hospital.Controllers
{

    [Authorize]

    public class UsuariosController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public UsuariosController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
   
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            // _emailSender = emailSender;
        }


        // GET: CuentasController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> SignUP(string returnurl = null)
        {
            //Creación de los roles
            if (!await _roleManager.RoleExistsAsync("Administrador"))
            {
                //Creamos el rol del usuario Administrador
                await _roleManager.CreateAsync(new IdentityRole("Administrador"));

            }
            //Creación de los roles
            if (!await _roleManager.RoleExistsAsync("Pacientes"))
            {
                //Creamos el rol del usuario Registrador
                await _roleManager.CreateAsync(new IdentityRole("Pacientes"));

            }
            if (!await _roleManager.RoleExistsAsync("Medicos"))
            {
                //Creamos el rol del usuario Registrador
                await _roleManager.CreateAsync(new IdentityRole("Medicos"));

            }
            ViewData["ReturnUrl"] = returnurl;
            signUp register = new signUp();
            return View(register);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> SignUP(signUp register, string returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;
            returnurl = returnurl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var usuario = new Usuario
                {
                    UserName = register.Email,
                    Email = register.Email,
                    Nombrecompletousuario = register.Nombrecompletousuario,
                    Dniusuario = register.Dniusuario,
                    Rucusuario = register.Rucusuario,
                    Celularusuario = register.Celularusuario,
                    Usuario1 = register.Usuario1,
                    FechaNacimiento = register.FechaNacimiento,
                    Estado = register.Estado
                };
                var resultado = await _userManager.CreateAsync(usuario, register.Password);

                if (resultado.Succeeded)
                {
                    //await _roleManager.CreateAsync(new IdentityRole("Administrador"));
                    await _userManager.AddToRoleAsync(usuario, "Administrador");

                    //Implementación de confirmación de email en el registro
                    // var code = await _userManager.GenerateEmailConfirmationTokenAsync(usuario);
                    //var urlRetorno = Url.Action("ConfirmarEmail", "Cuentas", new { userId = usuario.Id, code = code }, protocol: HttpContext.Request.Scheme);
                    //await _emailSender.SendEmailAsync(rgViewModel.Email, "Confirmar su cuenta - Proyecto Identity",
                    //"Por favor confirme su cuenta dando click aquí: <a href=\"" + urlRetorno + "\">enlace</a>");


                    await _signInManager.SignInAsync(usuario, isPersistent: false);
                    //return RedirectToAction("Index", "Home");
                    return LocalRedirect(returnurl);
                }

                ValidarErrores(resultado);
            }

            return View(register);
        }

        //Manejador de errores
        private void ValidarErrores(IdentityResult resultado)
        {
            foreach (var error in resultado.Errors)
            {
                ModelState.AddModelError(String.Empty, error.Description);
            }
        }
        //Función para mostrar el formulario de acceso
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> SignIN()
        {
           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> SignIN(signIn sign, string returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;
            returnurl = returnurl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var resultado = await _signInManager.PasswordSignInAsync(sign.Usuario1,
                    sign.Password, sign.RememberMe, lockoutOnFailure: true);
                if (resultado.Succeeded)
                {
                    return LocalRedirect(returnurl);
                  
                }
                if (resultado.IsLockedOut)
                {
                    return View("Bloqueado");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Intentelo Mas tarde");

                    return RedirectToAction("Dashboard", "Home");
                }

                

            }
            return View(sign);
        }
        //Salir o cerrar la sesión de la aplicación
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return RedirectToAction("Index", "Home");
        }
       
       

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult AccesoExterno(string provedor, string returnurl = null)
        {
            return View();
        }

        //Función para olvido de contraseña
        [HttpGet]
        public IActionResult OlvidoPassword()
        {
            return View();

        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ConfirmacionOlvidoPassword()
        {
            return View();
        }
        //Registro especial solo para los administrador
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> RegistroAdministrador(string returnurl = null)
        {
            //Para la creación de los roles
            if (!await _roleManager.RoleExistsAsync("Administrador"))
            {
                //Creación de rol usuario Administrador
                await _roleManager.CreateAsync(new IdentityRole("Administrador"));
            }
            //Para la creación de los roles
            if (!await _roleManager.RoleExistsAsync("Medicos"))
            {
                //Creación de rol usuario Registrado
                await _roleManager.CreateAsync(new IdentityRole("Medicos"));
            }
            if (!await _roleManager.RoleExistsAsync("Pacientes"))
            {
                //Creación de rol usuario Registrado
                await _roleManager.CreateAsync(new IdentityRole("Pacientes"));
            }
            //Para selección de rol
            List<SelectListItem> listaRoles = new List<SelectListItem>();
            listaRoles.Add(new SelectListItem()
            {
                Value = "Medicos",
                Text = "Medicos"
            });
            listaRoles.Add(new SelectListItem()
            {
                Value = "Administrador",
                Text = "Administrador"
            });
            listaRoles.Add(new SelectListItem()
            {
                Value = "Medicos",
                Text = "Medicos"
            });

            ViewData["ReturnUrl"] = returnurl;
            signUp registroVM = new signUp()
            {
                ListaRoles = listaRoles
            };
            return View(registroVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> RegistroAdministrador(signUp register, string returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;
            returnurl = returnurl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var usuario = new Usuario
                {
                    UserName = register.Email,
                    Email = register.Email,
                    Nombrecompletousuario = register.Nombrecompletousuario,
                    Celularusuario = register.Celularusuario,
                    Dniusuario = register.Dniusuario,
                    Rucusuario = register.Rucusuario,
                    Usuario1 = register.Usuario1,
                    FechaNacimiento = register.FechaNacimiento,
                    
                    Estado = register.Estado
                };
                var resultado = await _userManager.CreateAsync(usuario, register.Password);

                if (resultado.Succeeded)
                {
                    //Para selección de rol en el registro
                    if (register.RolSeleccionado != null && register.RolSeleccionado.Length > 0 &&
                                                     register.RolSeleccionado == "Administrador")
                    {
                        await _userManager.AddToRoleAsync(usuario, "Administrador");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(usuario, "Medicos");
                        await _userManager.AddToRoleAsync(usuario, "Pacientes");
                    }



                    //Esta línea es para la asignación del usuario que se registra al rol "Registrado"
                    await _userManager.AddToRoleAsync(usuario, "Medicos");


                    await _userManager.AddToRoleAsync(usuario, "Pacientes");



                    await _signInManager.SignInAsync(usuario, isPersistent: false);
                    //return RedirectToAction("Index", "Home");
                    return LocalRedirect(returnurl);
                }

                ValidarErrores(resultado);
            }

            //Para selección de rol
            List<SelectListItem> listaRoles = new List<SelectListItem>();
            listaRoles.Add(new SelectListItem()
            {
                Value = "Medicos",
                Text = "Medicos"
            });

            listaRoles.Add(new SelectListItem()
            {
                Value = "Administrador",
                Text = "Administrador"
            });
            listaRoles.Add(new SelectListItem()
            {
                Value = "Pacientes",
                Text = "Pacientes"
            });

            register.ListaRoles = listaRoles;

            return View(register);
        }


    }
}


