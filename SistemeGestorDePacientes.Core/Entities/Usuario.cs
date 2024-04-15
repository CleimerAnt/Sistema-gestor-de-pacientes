using SistemeGestorDePacientes.Core.Commons;


namespace SistemeGestorDePacientes.Core.Entities
{
    public class Usuario : AuditableDaseEntity
    {
       
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string NombreDeUsuario { get; set; }
        public string Contraseña { get; set; }
        public string TipoUsuario { get; set; }
    }
}
