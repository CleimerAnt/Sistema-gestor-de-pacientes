using Microsoft.AspNetCore.Http;


namespace SistemaGestorDePacientes.Core.Application.ViewModel.MedicoViewModel
{
    public class MedicoViewModel
    {
        public int Id { get; set; }
      
        public string Nombre { get; set; }
  
        public string Apellido { get; set; }
       
        public string Correo { get; set; }
      
        public string Telefono { get; set; }
     
        public string Cedula { get; set; }
        public string ImgUrl { get; set; }
     
        public IFormFile file { get; set; }

        public ICollection<CitasViewModel.CitasViewModel> Citas { get; set; }
    }
}
