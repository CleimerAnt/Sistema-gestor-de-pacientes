using SistemeGestorDePacientes.Core.Commons;

namespace SistemeGestorDePacientes.Core.Entities
{
    public class PruebasLaboratorio : AuditableDaseEntity
    {
        public string NombreDeLaPrueba { get; set; }
      
        //Propiedad de Navegacion
        public ICollection<ResultadosDeLaboratorio> resultadosDeLaboratorios { get; set; }    

    }
}
