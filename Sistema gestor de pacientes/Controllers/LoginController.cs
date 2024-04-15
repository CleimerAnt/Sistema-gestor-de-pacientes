
using SistemaGestorDePacientes.Core.Application.Helpers;
using Microsoft.AspNetCore.Mvc;
using SistemaGestorDePacientes.Core.Application.Interfaces.Servicios;
using SistemaGestorDePacientes.Core.Application.ViewModel;
using SistemeGestorDePacientes.Infraestructure.Persistence.Context;
using SistemeGestorDePacientes.Core.Entities;
using Microsoft.EntityFrameworkCore;
using SistemaGestorDePacientes.Core.Application.ViewModel.UsuarioViewModel;
using Sistema_gestor_de_pacientes.Middlewares;


namespace Sistema_gestor_de_pacientes.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioServicio _usuarioServicio;
        private readonly ApplicationContext _Context;
        private readonly ValidateUserSession _validateUserSession;
        public LoginController(IUsuarioServicio usuarioServicio, ApplicationContext context, ValidateUserSession validateUserSession )
        {
            _usuarioServicio = usuarioServicio;
            _Context = context;
            _validateUserSession = validateUserSession; 
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Index(LoginViewModel loginVm)
        {
            if(!ModelState.IsValid)
            {
                return View(loginVm);
            }

            UsuarioViewModel usuarioVm = await _usuarioServicio.Login(loginVm);
            

            if(usuarioVm is not null)
            {
                if(usuarioVm.TipoUsuario == "Administrador")
                {
                    HttpContext.Session.set<UsuarioViewModel>("Administrador", usuarioVm);

                    return RedirectToAction("Index", "Usuario");
                }
                else if (usuarioVm.TipoUsuario == "Usuario Ayudante")
                {
                    HttpContext.Session.set<UsuarioViewModel>("Usuario Ayudante", usuarioVm);
                    return RedirectToAction("Index", "Paciente");
                }

            }

            else
            {
                ModelState.AddModelError("User Validation", "Datos Incorrectos," +
                    " Debe colocar el Nombre de Usuario y la Contraseña Correctamente");
            }

            return View(loginVm);
        }

        public async Task<ActionResult <UsuarioViewModel>> Registro()
        {
         

            return View("Registro", new UsuarioPostViewModel());
        }
        [HttpPost]
        public async Task<ActionResult<UsuarioViewModel>> Registro(UsuarioPostViewModel usuario)
        {
           

            if (!ModelState.IsValid)
            {
                return View(usuario);
            }
            if(usuario.TipoUsuario == "1")
            {
                usuario.TipoUsuario = "Administrador";
            }

            else if(usuario.TipoUsuario == "2")
            {
                usuario.TipoUsuario = "Usuario Ayudante";
            }

            var modelo = await _Context.Set<Usuario>()
               .FirstOrDefaultAsync(u => u.NombreDeUsuario.ToUpper() == usuario.NombreDeUsuario.ToUpper());

            if(modelo is not null)
            {
                ModelState.AddModelError("Usuario existente", "El Nombre ya esta en uso, debe" +
                    " ingresar otro nombre");
                return View(usuario);
            }
           
            await _usuarioServicio.AddAsync(usuario);

            return RedirectToAction("Index", "Usuario");
        }

    }
}
