
using SistemaGestorDePacientes.Core.Application.ViewModel;
using SistemaGestorDePacientes.Core.Application.ViewModel.UsuarioViewModel;
using SistemeGestorDePacientes.Core.Entities;


namespace SistemaGestorDePacientes.Core.Application.Interfaces.Servicios
{
    public interface IUsuarioServicio : IGenericServicio<UsuarioViewModel, UsuarioPostViewModel, Usuario>
    {
        Task<UsuarioViewModel> Login(LoginViewModel LoginVm);
    }
}
