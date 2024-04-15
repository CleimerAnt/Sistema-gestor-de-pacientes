using SistemaGestorDePacientes.Core.Application.ViewModel.ResultadosPruebaViewModel;
using SistemeGestorDePacientes.Core.Entities;


namespace SistemaGestorDePacientes.Core.Application.Interfaces.Servicios
{
    public interface IResultadoPruebaServicio : IGenericServicio<ResultadosPruebaViewModel, ResultadosPruebaPostViewModel, ResultadosDeLaboratorio>
    {
        Task<List<ResultadosPruebaViewModel>> GetAllForCita(int Id);
        Task<List<ResultadosPruebaViewModel>> GetForCedula(string cedula);
        Task EditarEstado(ResultadosPruebaPostViewModel Vm);
        Task<List<ResultadosPruebaViewModel>> GetAllAsyncCitaCompletada(int Id);
    }
}
