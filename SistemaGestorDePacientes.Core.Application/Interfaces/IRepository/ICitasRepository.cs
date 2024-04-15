using SistemaGestorDePacientes.Core.Application.ViewModel.CitasViewModel;
using SistemeGestorDePacientes.Core.Entities;


namespace SistemaGestorDePacientes.Core.Application.Interfaces.IRepository
{
    public interface ICitasRepository : IGenericRepository<Citas>
    {
        Task<List<CitasViewModel>> GetAllLINQ();

    }
}
