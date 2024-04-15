using SistemeGestorDePacientes.Core.Commons;

namespace SistemeGestorDePacientes.Core.Entities
{
    public class Pacientes : AuditableDaseEntity
    {
        
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public bool EsFumador { get; set; }
        public bool TieneAlergias { get; set; }
        public string? ImgUrl { get; set; }

        // Propiedad de Navegacion
        public ICollection<ResultadosDeLaboratorio> resultadosDeLaboratorios { get; set; }
        public ICollection<Citas> Citas { get; set; }

    }
}
