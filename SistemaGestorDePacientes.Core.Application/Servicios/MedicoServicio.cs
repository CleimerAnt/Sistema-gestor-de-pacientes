using AutoMapper;
using SistemaGestorDePacientes.Core.Application.Interfaces.IRepository;
using SistemaGestorDePacientes.Core.Application.Interfaces.Servicios;

using SistemaGestorDePacientes.Core.Application.ViewModel.MedicoViewModel;

using SistemeGestorDePacientes.Core.Entities;


namespace SistemaGestorDePacientes.Core.Application.Servicios
{
    public class MedicoServicio : GeneralServicio<MedicoViewModel, MedicoPostViewModel, Medico>, IMedicoServicio    
    {
        private readonly IMedicoRepository _medicoRepository;
        private readonly IMapper _mapper;
        public MedicoServicio(IMedicoRepository medicoRepository, IMapper mapper) : base(medicoRepository, mapper)
        {
            _medicoRepository = medicoRepository;
            _mapper = mapper;
        }

     

    }
}
