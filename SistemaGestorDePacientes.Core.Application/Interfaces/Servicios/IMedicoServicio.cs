using SistemaGestorDePacientes.Core.Application.ViewModel.MedicoViewModel;
using SistemeGestorDePacientes.Core.Entities;


namespace SistemaGestorDePacientes.Core.Application.Interfaces.Servicios
{
    public interface IMedicoServicio : IGenericServicio<MedicoViewModel, MedicoPostViewModel, Medico>
    {
    }
}
