
using SistemaGestorDePacientes.Core.Application.ViewModel.PacientesViewModel;

using System.ComponentModel.DataAnnotations;


namespace SistemaGestorDePacientes.Core.Application.ViewModel.CitasViewModel
{
    public class CitasPostViewModel
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="El Campo paciente es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe Seleccionar un Paciente")]
        public int PacienteId { get; set; }
        [Required(ErrorMessage = "El Campo medico es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe Seleccionar una Medico")]
        public int MedicoId { get; set; }
        [Required(ErrorMessage = "El Campo Fecha de la Cita es requerido")]
        [DataType (DataType.DateTime)]
        public DateTime FechaCita { get; set; }
        [Required(ErrorMessage = "El Campo Hora de la Cita es requerido")]
        [DataType(DataType.DateTime)]
        public TimeSpan HoraCita { get; set; }
        [Required(ErrorMessage = "El Campo Causa de la Cita es requerido")]
        [DataType(DataType.Text)]
        public string CausaDeLaCita { get; set; }
        
        [DataType(DataType.Text)]
        public string? EstadoDelaCita { get; set; }

        public PacienteViewModel? pacientes { get; set; }
        public MedicoViewModel.MedicoViewModel? medico { get; set; }
        public ICollection<ResultadosPruebaViewModel.ResultadosPruebaViewModel>? resultadosDeLaboratorios { get; set; }
    }
}
