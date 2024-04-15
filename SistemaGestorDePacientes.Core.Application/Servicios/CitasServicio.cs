using AutoMapper;
using SistemaGestorDePacientes.Core.Application.Interfaces.IRepository;
using SistemaGestorDePacientes.Core.Application.Interfaces.Servicios;
using SistemaGestorDePacientes.Core.Application.ViewModel.CitasViewModel;
using SistemeGestorDePacientes.Core.Entities;


namespace SistemaGestorDePacientes.Core.Application.Servicios
{
    public class CitasServicio : GeneralServicio<CitasViewModel, CitasPostViewModel, Citas>, ICitasServicio
    { 
        private readonly ICitasRepository _citasRepository;
        private readonly IMapper _Mapper;
        public CitasServicio(ICitasRepository citasRepository, IMapper mapper): base(citasRepository, mapper)
        {
            _citasRepository = citasRepository; 
            _Mapper = mapper;
        }
        
        public  async Task cambiarEstadoCitaPendiente (CitasPostViewModel Vm)
        {
          
            Citas citas = _Mapper.Map<Citas>(Vm);

            citas.EstadoDelaCita = "Pendiente de Resultados";
            await _citasRepository.UpdateAsync(citas, citas.Id);

        }
        public async Task camibarEstadoCitaCompletado(CitasPostViewModel Vm)
        {
            Citas citas = await _citasRepository.GetByIdAsync(Vm.Id);
            _Mapper.Map<Citas>(Vm);
          
            citas.EstadoDelaCita = "Completada";

            await _citasRepository.UpdateAsync(citas,citas.Id);

        }
        
        public override async Task<List<CitasViewModel>> GetAllAsync()
        {
            /* var ListaCitas = await _citasRepository.GetAllLINQ();

             var modelo = ListaCitas.Select(citas => new CitasViewModel
             {
                 Id = citas.Id,  
                 PacienteId = citas.PacienteId,
                 MedicoId = citas.MedicoId,
                 CausaDeLaCita = citas.CausaDeLaCita,
                 HoraCita = citas.HoraCita,
                 EstadoDelaCita = citas.EstadoDelaCita,
                 FechaCita = citas.FechaCita,
                 MedicoNombre = citas.MedicoNombre,
                 PacienteNombre = citas.PacienteNombre  
             });

             return modelo.ToList();*/
            var ListaCitas = await _citasRepository.GetAllLINQ();
            var modelo = _Mapper.Map<List<CitasViewModel>>(ListaCitas);

            
           return modelo;
        }
      
    }
}
