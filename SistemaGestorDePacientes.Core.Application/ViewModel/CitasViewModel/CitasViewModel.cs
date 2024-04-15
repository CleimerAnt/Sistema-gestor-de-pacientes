
using SistemaGestorDePacientes.Core.Application.ViewModel.PacientesViewModel;



namespace SistemaGestorDePacientes.Core.Application.ViewModel.CitasViewModel
{
    public class CitasViewModel
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public DateTime FechaCita { get; set; }
        public TimeSpan HoraCita { get; set; }
        public string CausaDeLaCita { get; set; }
        public string EstadoDelaCita { get; set; }

        // Propiedades de la Relacion
        public string PacienteNombre { get; set; }  
        public string MedicoNombre { get; set; }


        public PacienteViewModel pacientes { get; set; }
        public MedicoViewModel.MedicoViewModel medicos { get; set; }

        public ICollection<ResultadosPruebaViewModel.ResultadosPruebaViewModel> resultadosDeLaboratorios { get; set; }

    }
}
