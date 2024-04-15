using AutoMapper;
using SistemaGestorDePacientes.Core.Application.Interfaces.IRepository;
using SistemaGestorDePacientes.Core.Application.Interfaces.Servicios;

using SistemaGestorDePacientes.Core.Application.ViewModel.PruebasLaboratorioViewModel;
using SistemeGestorDePacientes.Core.Entities;


namespace SistemaGestorDePacientes.Core.Application.Servicios
{
    public class PruebasLaboratorioServicio : GeneralServicio<PruebasLaboratioViewModel, PruebaLaboratorioPostViewModel, PruebasLaboratorio>, IPruebasLaboratorioServicio
    {
        private readonly IPruebasLaboratorioRepository _pruebasRepository;
        private readonly IMapper _mapper;
        public PruebasLaboratorioServicio(IPruebasLaboratorioRepository pruebasLaboratorio, IMapper mapper) : base(pruebasLaboratorio, mapper)  
        {
            _pruebasRepository = pruebasLaboratorio;
            _mapper = mapper;
        }
      
      
    }
}
