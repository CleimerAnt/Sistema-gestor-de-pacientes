using Microsoft.AspNetCore.Http;
using SistemaGestorDePacientes.Core.Application.Helpers;
using SistemaGestorDePacientes.Core.Application.ViewModel.UsuarioViewModel;

namespace Sistema_gestor_de_pacientes.Middlewares
{
    public class ValidateUserSession
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public ValidateUserSession(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public bool HasUserAdmin()
        {
            UsuarioViewModel usuarioViewModel = _contextAccessor.HttpContext.Session.get<UsuarioViewModel>("Administrador");

            if (usuarioViewModel == null)
            {
                return false;
            }

            return true;
        }

        public bool HasUserAyudante()
        {
            UsuarioViewModel usuarioViewModel = _contextAccessor.HttpContext.Session.get<UsuarioViewModel>("Usuario Ayudante");

            if (usuarioViewModel == null)
            {
                return false;
            }

            return true;
        }
    }
}
