using SistemaGestorDePacientes.Core.Application.ViewModel.CitasViewModel;
using SistemeGestorDePacientes.Core.Entities;


namespace SistemaGestorDePacientes.Core.Application.Interfaces.Servicios
{
    public interface ICitasServicio : IGenericServicio<CitasViewModel, CitasPostViewModel, Citas>
    {
        Task cambiarEstadoCitaPendiente(CitasPostViewModel Vm);
        Task camibarEstadoCitaCompletado(CitasPostViewModel Vm);
    }
}
