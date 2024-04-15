
using System.ComponentModel.DataAnnotations;


namespace SistemaGestorDePacientes.Core.Application.ViewModel.UsuarioViewModel;

public class UsuarioPostViewModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "El Campo Nombre es Requerido")]
    public string Nombre { get; set; }
    [Required(ErrorMessage = "El Campo Apellido es Requerido")]
    public string Apellido { get; set; }
    [Required(ErrorMessage = "El Campo Correo es Requerido")]
    public string Correo { get; set; }
    [Required(ErrorMessage = "El Campo Nombre de Usuario es Requerido")]
    public string NombreDeUsuario { get; set; }
    [Required(ErrorMessage = "El Campo Contraseña es Requerido")]
    public string Contraseña { get; set; }
    [Required(ErrorMessage = "El Campo Tipo de Usuario es Requerido")]
    [Range(1, int.MaxValue, ErrorMessage = "Debe Seleccionar un tipo de Usuario")]
    public string TipoUsuario { get; set; }
    [Required(ErrorMessage = "El Campo Confirmar contraseña es Requerido")]

    [Compare(nameof(Contraseña), ErrorMessage = "Las Contraseñas deben conincidir")]
    public string ConfirmarContraseña { get; set; }
}
