
using System.ComponentModel.DataAnnotations;

namespace SistemaGestorDePacientes.Core.Application.ViewModel.ResultadosPruebaViewModel
{
    public class ResultadosPruebaPostViewModel
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "El Campo Paciente es Requerido")]
        public int pacienteId { get; set; }
       
        public int  pruebaLaboratorioId { get; set; }
        public string EstadoPrueba { get; set; }

        public int citaId { get; set; }
       
        public string? ResultadoPrueba { get; set; }

        public PacientesViewModel.PacienteViewModel? Pacientes { get; set; }
        public PruebasLaboratorioViewModel.PruebasLaboratioViewModel? PruebasLaboratorio { get; set; }
        public CitasViewModel.CitasViewModel? citas { get; set; }
        [Required (ErrorMessage = "Debe Seleccionar una Prueba de Laboratorio")]
        public List<int> opciones { get; set; }    

    }
}
