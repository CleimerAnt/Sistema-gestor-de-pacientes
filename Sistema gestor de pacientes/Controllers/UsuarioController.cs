
using Microsoft.AspNetCore.Mvc;
using Sistema_gestor_de_pacientes.Middlewares;
using SistemaGestorDePacientes.Core.Application.Interfaces.Servicios;
using SistemaGestorDePacientes.Core.Application.ViewModel.UsuarioViewModel;





namespace Sistema_gestor_de_pacientes.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioServicio _usuarioServicio;
        private readonly ValidateUserSession _validateUserSession;  
        public UsuarioController(IUsuarioServicio usuarioServicio, ValidateUserSession validateUserSession)
        {
            _usuarioServicio = usuarioServicio;
            _validateUserSession = validateUserSession; 
        }

        public async Task <IActionResult> Index()
        {
            if (!_validateUserSession.HasUserAdmin())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }


            var usuarios = await _usuarioServicio.GetAllAsync(); 
            
            return View(usuarios);
        }

        public async Task <IActionResult> Eliminar(int Id)
        {
            if (!_validateUserSession.HasUserAdmin())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            return View("Eliminar", await _usuarioServicio.GetById(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(UsuarioPostViewModel usuarioVm)
        {
            if (!_validateUserSession.HasUserAdmin())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            await _usuarioServicio.Eliminar(usuarioVm.Id);

            return RedirectToAction("Index", "Usuario");
        }

        public async Task <IActionResult> Editar(int Id)
        {

            if (!_validateUserSession.HasUserAdmin())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }
            var usuarios = await _usuarioServicio.GetById(Id);

            if (usuarios.TipoUsuario == "Administrador")
            {
                usuarios.TipoUsuario = "1";
            }

            else if (usuarios.TipoUsuario == "Usuario Ayudante")
            {
                usuarios.TipoUsuario = "2";
            }


            return View("~/Views/Login/Registro.cshtml",usuarios );

        }
        [HttpPost]
        public async Task<IActionResult> Editar(UsuarioPostViewModel usuario)
        {

            if (!_validateUserSession.HasUserAdmin())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            if (!ModelState.IsValid)
            {
                return View("~/Views/Login/Registro.cshtml", usuario);
            }

            if (usuario.TipoUsuario == "1")
            {
                usuario.TipoUsuario = "Administrador";
            }

            else if (usuario.TipoUsuario == "2")
            {
                usuario.TipoUsuario = "Usuario Ayudante";
            }

            await _usuarioServicio.Editar(usuario, usuario.Id);

            return RedirectToAction("Index", "Usuario");
        }

        public async Task<IActionResult> CerrarSesion()
        {
            HttpContext.Session.Remove("Usuario Ayudante");

            HttpContext.Session.Remove("Administrador");

            return RedirectToAction("Index", "Login");
        }
    }
}
