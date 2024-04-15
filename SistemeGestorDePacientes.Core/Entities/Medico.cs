using SistemeGestorDePacientes.Core.Commons;

namespace SistemeGestorDePacientes.Core.Entities
{
    public class Medico : AuditableDaseEntity
    {
      
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Cedula { get; set; }
        public string? ImgUrl { get; set; }

        //Propiedad de Navegacion
        public ICollection<Citas> Citas { get; set; }    
       
    }
}
