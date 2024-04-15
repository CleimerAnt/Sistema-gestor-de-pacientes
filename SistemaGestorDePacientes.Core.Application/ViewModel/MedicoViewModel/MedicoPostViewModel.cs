
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace SistemaGestorDePacientes.Core.Application.ViewModel.MedicoViewModel
{
    public class MedicoPostViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El Nombre es Requerido")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Apellido es Requerido")]
        [DataType(DataType.Text)]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El Correo es Requerido")]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }
        [DataType(DataType.Text)]
        public string Cedula { get; set; }
        public string? ImgUrl { get; set; }
        
        public IFormFile? File { get; set; }

        public ICollection<CitasViewModel.CitasViewModel>? Citas { get; set; }

    }
}
