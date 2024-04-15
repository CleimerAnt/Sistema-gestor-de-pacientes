
using System.ComponentModel.DataAnnotations;

namespace SistemaGestorDePacientes.Core.Application.ViewModel
{
    public class LoginViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Campo Nombre es Requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Campo Contraseña es Requerido")]
        public string Contraseña { get; set; }
    }
}
