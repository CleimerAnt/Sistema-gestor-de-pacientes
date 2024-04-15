
using SistemaGestorDePacientes.Core.Application.ViewModel;
using SistemeGestorDePacientes.Core.Entities;


namespace SistemaGestorDePacientes.Core.Application.Interfaces.IRepository
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Task<Usuario> Login(LoginViewModel loginVm);
        
    }
}
