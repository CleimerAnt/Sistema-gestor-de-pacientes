using AutoMapper;
using SistemaGestorDePacientes.Core.Application.Interfaces.IRepository;
using SistemaGestorDePacientes.Core.Application.Interfaces.Servicios;
using SistemaGestorDePacientes.Core.Application.ViewModel.ResultadosPruebaViewModel;
using SistemeGestorDePacientes.Core.Entities;


namespace SistemaGestorDePacientes.Core.Application.Servicios
{
    public class ResultadosPruebaServicio : GeneralServicio<ResultadosPruebaViewModel, ResultadosPruebaPostViewModel, ResultadosDeLaboratorio>, IResultadoPruebaServicio
    {
        private readonly IResultadosPruebaRepository _resultadosPruebaRepository;
        private readonly IMapper _mapper;
        public ResultadosPruebaServicio(IResultadosPruebaRepository resultadosPruebaRepository, IMapper mapper) : base(resultadosPruebaRepository, mapper)
        {
            _resultadosPruebaRepository = resultadosPruebaRepository;
            _mapper = mapper;
        }

        public virtual async Task EditarEstado(ResultadosPruebaPostViewModel Vm)
        {
            ResultadosDeLaboratorio resultados = _mapper.Map<ResultadosDeLaboratorio>(Vm);

            resultados.EstadoPrueba = "Completada";
            resultados.citaId = Vm.citaId;

            await _resultadosPruebaRepository.UpdateAsync(resultados, Vm.Id);
        }

        
        public virtual async Task<ResultadosPruebaPostViewModel> AddAsync(ResultadosPruebaPostViewModel resultadoVm)
        {
            var resultadosDeLaboratorio = _mapper.Map<ResultadosDeLaboratorio>(resultadoVm);
            resultadosDeLaboratorio = await _resultadosPruebaRepository.AddAsync(resultadosDeLaboratorio);
            var resultadosPost = _mapper.Map<ResultadosPruebaPostViewModel>(resultadosDeLaboratorio);  

          
           return resultadosPost;
          
        }


        public async Task Eliminar(int Id)
        {
            ResultadosDeLaboratorio resultados = new();

            await _resultadosPruebaRepository.Remove(resultados);
           
        }

        public virtual async Task <List<ResultadosPruebaViewModel>> GetAllAsync()
        {

            var ListaResultados = await _resultadosPruebaRepository.GetAllAsyncLINQ();
            var modelo = _mapper.Map<List<ResultadosPruebaViewModel>>(ListaResultados);
 
            return modelo.ToList();
        }

        public async Task<List<ResultadosPruebaViewModel>> GetAllAsyncCitaCompletada(int Id)
        {
            
            var ListaResultados = await _resultadosPruebaRepository.GetAllAsyncCitaCompletada(Id);
            var modelo = _mapper.Map<List<ResultadosPruebaViewModel>>(ListaResultados);
           
            return modelo.ToList();
        }
        public async Task<List<ResultadosPruebaViewModel>> GetAllForCita(int Id)
        {
            

            var lista = await _resultadosPruebaRepository.GetPruebaForCita(Id);
            var modelo = _mapper.Map<List<ResultadosPruebaViewModel>>(lista);
           

            return modelo.ToList(); 
        }
        public async Task<List<ResultadosPruebaViewModel>> GetForCedula(string cedula)
        {
           
            var lista = await _resultadosPruebaRepository.GetForCedula(cedula);
            var modelo = _mapper.Map<List<ResultadosPruebaViewModel>>(lista);
  
            return modelo.ToList();
        }
     
    }
}
