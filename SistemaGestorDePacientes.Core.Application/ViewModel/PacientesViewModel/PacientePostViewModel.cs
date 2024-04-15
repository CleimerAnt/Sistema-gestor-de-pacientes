using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace SistemaGestorDePacientes.Core.Application.ViewModel.PacientesViewModel
{
    public class PacientePostViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El Campo Nombre es Requerido")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Campo Apellido es Requerido")]
        [DataType(DataType.Text)]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El Campo Telefono es Requerido")]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El Campo Direccion es Requerido")]

        public string Direccion { get; set; }
        [Required(ErrorMessage = "El Campo Cedula es Requerido")]

        public string Cedula { get; set; }
        [Required(ErrorMessage = "El Campo Fecha de Nacimiento es Requerido")]
        [DataType(DataType.DateTime)]
        public DateTime FechaDeNacimiento { get; set; }
        [Required(ErrorMessage = "El Campo Fumador es Requerido")]

        public bool EsFumador { get; set; }
        [Required(ErrorMessage = "El Campo Alergias es Requerido")]

        public bool TieneAlergias { get; set; }
        public string? ImgUrl { get; set; }

        
        public IFormFile? File { get; set; }

        public ICollection<ResultadosPruebaViewModel.ResultadosPruebaViewModel>? resultadosDeLaboratorios { get; set; }
        public ICollection<CitasViewModel.CitasViewModel>? Citas { get; set; }
    }
}
