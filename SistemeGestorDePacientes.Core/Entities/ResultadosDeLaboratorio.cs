using SistemeGestorDePacientes.Core.Commons;


namespace SistemeGestorDePacientes.Core.Entities
{
    public class ResultadosDeLaboratorio : AuditableDaseEntity
    {
       
        public int Id {  get; set; }    
        public int pacienteId { get; set; } 
        public int pruebaLaboratorioId { get; set; }    
        public int citaId { get; set; } 
        public string EstadoPrueba { get; set; }
        public string? ResultadoPrueba { get; set; }

        //Propiedades de Navegacion
        public Pacientes Pacientes { get; set; }
        public PruebasLaboratorio PruebasLaboratorio { get; set; }
        public Citas citas { get; set;  }  

    }
}
