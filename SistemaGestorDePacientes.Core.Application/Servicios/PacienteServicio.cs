using AutoMapper;
using SistemaGestorDePacientes.Core.Application.Interfaces.IRepository;
using SistemaGestorDePacientes.Core.Application.Interfaces.Servicios;

using SistemaGestorDePacientes.Core.Application.ViewModel.PacientesViewModel;
using SistemeGestorDePacientes.Core.Entities;


namespace SistemaGestorDePacientes.Core.Application.Servicios
{
    public class PacienteServicio : GeneralServicio<PacienteViewModel, PacientePostViewModel, Pacientes>,IPacienteServicio
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMapper _mapper;
        public PacienteServicio(IPacienteRepository pacienteRepository, IMapper mapper): base(pacienteRepository, mapper)
        {
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
        }
       
      
    }
}
