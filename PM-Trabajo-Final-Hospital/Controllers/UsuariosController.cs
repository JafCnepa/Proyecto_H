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
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public UsuariosController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
            this._roleManager = roleManager;
            this._context = context;
            // _emailSender = emailSender;
        }


    
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
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
                var resultado = await userManager.CreateAsync(usuario, register.Password);

                if (resultado.Succeeded)
                {
                    //await _roleManager.CreateAsync(new IdentityRole("Administrador"));
                    await userManager.AddToRoleAsync(usuario, "Administrador");

                    //Implementación de confirmación de email en el registro
                    // var code = await _userManager.GenerateEmailConfirmationTokenAsync(usuario);
                    //var urlRetorno = Url.Action("ConfirmarEmail", "Cuentas", new { userId = usuario.Id, code = code }, protocol: HttpContext.Request.Scheme);
                    //await _emailSender.SendEmailAsync(rgViewModel.Email, "Confirmar su cuenta - Proyecto Identity",
                    //"Por favor confirme su cuenta dando click aquí: <a href=\"" + urlRetorno + "\">enlace</a>");


                    await signInManager.SignInAsync(usuario, isPersistent: false);
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
                var resultado = await signInManager.PasswordSignInAsync(sign.Usuario1,
                    sign.Password, sign.RememberMe, lockoutOnFailure: true);
                if (resultado.Succeeded)
                {
                    Redirect (returnurl);
                  
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
                Value = "Pacientes",
                Text = "Pacientes"
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
                var resultado = await userManager.CreateAsync(usuario, register.Password);

                if (resultado.Succeeded)
                {
                    //Para selección de rol en el registro
                    if (register.RolSeleccionado != null && register.RolSeleccionado.Length > 0 &&
                                                     register.RolSeleccionado == "Administrador")
                    {
                        await userManager.AddToRoleAsync(usuario, "Administrador");
                    }
                    else
                    {
                        await userManager.AddToRoleAsync(usuario, "Medicos");
                        await userManager.AddToRoleAsync(usuario, "Pacientes");
                    }



                    //Esta línea es para la asignación del usuario que se registra al rol "Registrado"
                    await userManager.AddToRoleAsync(usuario, "Medicos");


                    await userManager.AddToRoleAsync(usuario, "Pacientes");



                    await signInManager.SignInAsync(usuario, isPersistent: false);
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
        [AllowAnonymous]
        [HttpGet]
        public ChallengeResult LoginExterno(string proveedor, string urlRetorno = null)
        {
            var urlRedireccion = Url.Action("RegistrarUsuarioExterno", values: new { urlRetorno });
            var propiedades = signInManager
                .ConfigureExternalAuthenticationProperties(proveedor, urlRedireccion);
            return new ChallengeResult(proveedor, propiedades);
        }

        [AllowAnonymous]
        public async Task<IActionResult> RegistrarUsuarioExterno(string urlRetorno = null,
            string remoteError = null)
        {
            urlRetorno = urlRetorno ?? Url.Content("~/");

            var mensaje = "";

            if (remoteError is not null)
            {
                mensaje = $"Error del proveedor externo: {remoteError}";
                return RedirectToAction("login", routeValues: new { mensaje });
            }

            var info = await signInManager.GetExternalLoginInfoAsync();
            if (info is null)
            {
                mensaje = "Error cargando la data de login externo";
                return RedirectToAction("login", routeValues: new { mensaje });
            }

            var resultadoLoginExterno = await signInManager.ExternalLoginSignInAsync(info.LoginProvider,
                info.ProviderKey, isPersistent: true, bypassTwoFactor: true);

            // Ya la cuenta existe
            if (resultadoLoginExterno.Succeeded)
            {
                return LocalRedirect(urlRetorno);
            }

            string email = "";

            if (info.Principal.HasClaim(c => c.Type == ClaimTypes.Email))
            {
                email = info.Principal.FindFirstValue(ClaimTypes.Email);
            }
            else
            {
                mensaje = "Error leyendo el email del usuario del proveedor";
                return RedirectToAction("login", routeValues: new { mensaje });
            }

            var usuario = new IdentityUser { Email = email, UserName = email };

            var resultadoCrearUsuario = await userManager.CreateAsync(usuario);

            if (!resultadoCrearUsuario.Succeeded)
            {
                mensaje = resultadoCrearUsuario.Errors.First().Description;
                return RedirectToAction("login", routeValues: new { mensaje });
            }

            var resultadoAgregarLogin = await userManager.AddLoginAsync(usuario, info);

            if (resultadoAgregarLogin.Succeeded)
            {
                await signInManager.SignInAsync(usuario, isPersistent: true, info.LoginProvider);
                return LocalRedirect(urlRetorno);
            }

            mensaje = "Ha ocurrido un error agregando el login";
            return RedirectToAction("login", routeValues: new { mensaje });
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(c => c.UsuarioId == id);
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges(true);
            return RedirectToAction("Index");
        }
        public IActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return View();
            }
            var usu = _context.Usuarios.Include(d => d.DetalleUsuario).FirstOrDefault(u => u.UsuarioId == id);
            if (usu == null)
            {
                return NotFound();
            }
            return View(usu);
        }
        [HttpPost]
        public IActionResult AgregarDetalle(Usuario usuario)
        {      //Si el Usuario no tienen detalle su ID Detale de Usu es 0, por lo tanto agregamos su detalle
            if (usuario.DetalleUsuario.DetalleUsuario_Id == 0)
            {
                _context.DetalleUsuario.Add(usuario.DetalleUsuario);
                _context.SaveChanges();
                //Crear el detalle de usuario
                var usuBD = _context.Usuarios.FirstOrDefault(u => u.UsuarioId == usuario.UsuarioId);
                usuBD.DetalleUsuario_Id = usuario.DetalleUsuario.DetalleUsuario_Id;
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }








    }
}


