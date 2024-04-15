
using SistemaGestorDePacientes.Core.Application.ViewModel.ResultadosPruebaViewModel;
using SistemeGestorDePacientes.Core.Entities;


namespace SistemaGestorDePacientes.Core.Application.Interfaces.IRepository
{
    public interface IResultadosPruebaRepository : IGenericRepository<ResultadosDeLaboratorio>
    {
        Task<List<ResultadosPruebaViewModel>> GetAllAsyncLINQ();
        Task<List<ResultadosPruebaViewModel>> GetPruebaForCita(int Id);
        Task<List<ResultadosPruebaViewModel>> GetForCedula(string cedula);
        Task<List<ResultadosPruebaViewModel>> GetAllAsyncCitaCompletada(int Id);


    }
}
