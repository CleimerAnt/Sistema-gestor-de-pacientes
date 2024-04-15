

using SistemeGestorDePacientes.Core.Entities;

namespace SistemaGestorDePacientes.Core.Application.ViewModel.PruebasLaboratorioViewModel
{
    public class PruebasLaboratioViewModel
    {
        public int Id { get; set; }
        public string NombreDeLaPrueba { get; set; }

        public ICollection<ResultadosPruebaViewModel.ResultadosPruebaViewModel> resultadosDeLaboratorios { get; set; }
    }
}
