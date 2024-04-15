using Microsoft.AspNetCore.Mvc;
using Sistema_gestor_de_pacientes.Middlewares;
using SistemaGestorDePacientes.Core.Application.Interfaces.Servicios;
using SistemaGestorDePacientes.Core.Application.ViewModel.PruebasLaboratorioViewModel;
using SistemaGestorDePacientes.Core.Application.ViewModel.ResultadosPruebaViewModel;


namespace Sistema_gestor_de_pacientes.Controllers
{
    public class ResultadosPruebaController : Controller
    {
        private readonly IResultadoPruebaServicio _resultadoPruebaServicio;
        private readonly IPruebasLaboratorioServicio _pruebasLaboratorioServicio;
        private readonly ICitasServicio _citasServicio;
        private readonly ValidateUserSession _validateUserSession;
        public ResultadosPruebaController(IResultadoPruebaServicio resultadoPruebaServicio 
            , IPruebasLaboratorioServicio pruebasLaboratorioServicio,
                ICitasServicio citasServicio, ValidateUserSession validateUserSession)
        {
            _resultadoPruebaServicio = resultadoPruebaServicio;
            _pruebasLaboratorioServicio = pruebasLaboratorioServicio;
            _citasServicio = citasServicio; 
            _validateUserSession = validateUserSession;
        }
        public async Task <IActionResult> Index()
        {
            if (!_validateUserSession.HasUserAyudante())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            var resultados = await _resultadoPruebaServicio.GetAllAsync();  

            return View(resultados);
        }
        [HttpPost]
        public async Task<IActionResult> Index(string cedulaVm)
        {
            if (!_validateUserSession.HasUserAyudante())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            List<ResultadosPruebaViewModel> cedula = await _resultadoPruebaServicio.GetForCedula(cedulaVm);

            var modelo = ViewBag.cedula = cedula;   

            return View(modelo);
        }

        public async Task<IActionResult> Create(int Id,int citaId)
        {
            if (!_validateUserSession.HasUserAyudante())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            List<PruebasLaboratioViewModel> pruebasLaboratorios = await _pruebasLaboratorioServicio.GetAllAsync();
            ViewBag.pruebas = pruebasLaboratorios;

            ViewBag.paciente = Id;

            ViewBag.citasId = citaId;    

           

            return View(new ResultadosPruebaPostViewModel());
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(ResultadosPruebaPostViewModel resultadosVm,int citaId)
        {
            if (!_validateUserSession.HasUserAyudante())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            if (!ModelState.IsValid)
            {
                List<PruebasLaboratioViewModel> pruebasLaboratorios = await _pruebasLaboratorioServicio.GetAllAsync();
                ViewBag.pruebas = pruebasLaboratorios;
                ViewBag.citasId = citaId;
                ViewBag.paciente = resultadosVm.pacienteId;

                return View(new ResultadosPruebaPostViewModel());
            }

            if(resultadosVm.Id != 0)
            {
               resultadosVm.Id = 0;
            }

            foreach(var pruebaID in resultadosVm.opciones)
            {
                resultadosVm.pruebaLaboratorioId = pruebaID;
                await _resultadoPruebaServicio.AddAsync(resultadosVm);
            }


            await CambiarEstadoCitas(citaId);

            return RedirectToAction("Index", "Citas");
        }

        public async Task<IActionResult> EstadoReultados(int Id, int CitaId)
        {
            if (!_validateUserSession.HasUserAyudante())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            ViewBag.Id = Id;    
            ViewBag.citaId = CitaId; 

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EstadoReultados(ResultadosPruebaPostViewModel Vm, int citaID)
        {

           
            if (!_validateUserSession.HasUserAyudante())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            var resultadoVm = await _resultadoPruebaServicio.GetById(Vm.Id);


            resultadoVm.ResultadoPrueba = Vm.ResultadoPrueba;
            resultadoVm.citaId = citaID;   

            await _resultadoPruebaServicio.EditarEstado(resultadoVm);

            return RedirectToAction("Index", "ResultadosPrueba");

           
        }
        
        public async Task<IActionResult> ResultadosCompletos(int Id)
        {
            if (!_validateUserSession.HasUserAyudante())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            var resultado = await _resultadoPruebaServicio.GetAllAsyncCitaCompletada(Id);

            return View(resultado);  
        }
        public async Task<IActionResult> ResultadosPorCita(int Id)
        {
            if (!_validateUserSession.HasUserAyudante())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            var resultado = await _resultadoPruebaServicio.GetAllForCita(Id);

            return View(resultado);
        }

        private async Task CambiarEstadoCitas(int Id)
        {
           

            var citas = await _citasServicio.GetById(Id);

            await _citasServicio.cambiarEstadoCitaPendiente(citas);
        }
    }
    
}

