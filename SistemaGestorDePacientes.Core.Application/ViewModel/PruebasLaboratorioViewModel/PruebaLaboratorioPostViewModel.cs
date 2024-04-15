

using System.ComponentModel.DataAnnotations;

namespace SistemaGestorDePacientes.Core.Application.ViewModel.PruebasLaboratorioViewModel
{
    public class PruebaLaboratorioPostViewModel
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "El Nombre de la Prueba es Requerido")]
        [DataType (DataType.Text)]
        public string NombreDeLaPrueba { get; set; }

        public ICollection<ResultadosPruebaViewModel.ResultadosPruebaViewModel>? resultadosDeLaboratorios { get; set; }
    }
}
