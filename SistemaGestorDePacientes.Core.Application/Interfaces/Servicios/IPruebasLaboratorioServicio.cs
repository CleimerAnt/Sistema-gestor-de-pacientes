using SistemaGestorDePacientes.Core.Application.ViewModel.PruebasLaboratorioViewModel;
using SistemeGestorDePacientes.Core.Entities;


namespace SistemaGestorDePacientes.Core.Application.Interfaces.Servicios
{
    public interface IPruebasLaboratorioServicio : IGenericServicio<PruebasLaboratioViewModel, PruebaLaboratorioPostViewModel,PruebasLaboratorio>
    {
    }
}
