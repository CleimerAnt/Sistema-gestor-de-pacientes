

namespace SistemaGestorDePacientes.Core.Application.ViewModel.PacientesViewModel
{
    public class PacienteViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public bool EsFumador { get; set; }
        public bool TieneAlergias { get; set; }
        public string ImgUrl { get; set; }

        public ICollection<ResultadosPruebaViewModel.ResultadosPruebaViewModel> resultadosDeLaboratorios { get; set; }
        public ICollection<CitasViewModel.CitasViewModel> Citas { get; set; }
    }
}
