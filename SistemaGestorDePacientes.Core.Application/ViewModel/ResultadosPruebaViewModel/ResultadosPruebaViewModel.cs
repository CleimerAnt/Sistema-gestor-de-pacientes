

namespace SistemaGestorDePacientes.Core.Application.ViewModel.ResultadosPruebaViewModel
{
    public class ResultadosPruebaViewModel
    {
        public int Id { get; set; }
        public int pacienteId { get; set; }
        public int pruebaLaboratorioId { get; set; }

        public int CitasId { get; set; }
        public string EstadoPrueba { get; set; }
        public string? ResultadoPrueba { get; set; }

        //Propiedades de Relacion
        public string pacienteNombre { get; set; }
        public string pacienteApellido { get; set; }    
        public string pacienteCedula { get; set; }  
        public string pruebaLaboratorioNombre { get; set; }


        public PacientesViewModel.PacienteViewModel Pacientes { get; set; }
        public PruebasLaboratorioViewModel.PruebasLaboratioViewModel PruebasLaboratorio { get; set; }
        public CitasViewModel.CitasViewModel citas { get; set; }
    }
}
