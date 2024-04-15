using SistemeGestorDePacientes.Core.Commons;


namespace SistemeGestorDePacientes.Core.Entities
{
    public class Citas : AuditableDaseEntity
    {
          
        public int PacienteId  { get; set; }
        public int MedicoId { get; set;}
        public DateTime FechaCita { get; set; }
        public TimeSpan HoraCita { get; set; }
        public string CausaDeLaCita { get; set; }
        public string EstadoDelaCita { get; set; }

        //Propiedades de Navegacion
        public Pacientes pacientes { get; set; }    
        public Medico medico { get; set; }  
        public ICollection<ResultadosDeLaboratorio> resultadosDeLaboratorios { get; set; }
    
    }
}
