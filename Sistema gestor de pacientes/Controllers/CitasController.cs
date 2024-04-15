using Microsoft.AspNetCore.Mvc;
using Sistema_gestor_de_pacientes.Middlewares;
using SistemaGestorDePacientes.Core.Application.Interfaces.Servicios;
using SistemaGestorDePacientes.Core.Application.ViewModel.CitasViewModel;
using SistemaGestorDePacientes.Core.Application.ViewModel.MedicoViewModel;
using SistemaGestorDePacientes.Core.Application.ViewModel.PacientesViewModel;



namespace Sistema_gestor_de_pacientes.Controllers
{
    public class CitasController : Controller
    {
        private readonly ICitasServicio _citasServicio;
        private readonly IPacienteServicio _pacienteServicio;
        private readonly IMedicoServicio _medicoServicio;
        private readonly ValidateUserSession _validateUserSession;
        public CitasController(ICitasServicio citasServicio,
       IPacienteServicio pacienteServicio, IMedicoServicio medicoServicio, ValidateUserSession validateUserSession)
        {
            _citasServicio = citasServicio;
            _pacienteServicio = pacienteServicio;
            _medicoServicio = medicoServicio;
            _validateUserSession = validateUserSession;
        }
        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.HasUserAyudante())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            var citasList = await _citasServicio.GetAllAsync();

            return View(citasList);
        }

        public async Task<IActionResult> Eliminar(int Id)
        {
            if (!_validateUserSession.HasUserAyudante())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            return View("Eliminar", await _citasServicio.GetById(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(CitasPostViewModel citasVm)
        {
            if (!_validateUserSession.HasUserAyudante())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            await _citasServicio.Eliminar(citasVm.Id);

            return RedirectToAction("Index", "Citas");
        }


        public async Task<IActionResult> Editar(int Id)
        {

            if (!_validateUserSession.HasUserAyudante())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            return View("Create", await _citasServicio.GetById(Id));

        }

        [HttpPost]
        public async Task<IActionResult> Editar(CitasPostViewModel citas)
        {
            if (!_validateUserSession.HasUserAyudante())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            if (!ModelState.IsValid)
            {
                return View("Create", citas);
            }

            await _citasServicio.Editar(citas, citas.Id);

            return RedirectToAction("Index", "Citas");
        }

        public async Task <IActionResult> Create()
        {
            if (!_validateUserSession.HasUserAyudante())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            List<PacienteViewModel> pacienteList = await _pacienteServicio.GetAllAsync();
            List<MedicoViewModel> medicoList = await _medicoServicio.GetAllAsync(); 

            ViewBag.medicos = medicoList;
            ViewBag.pacientes = pacienteList;

            return View(new CitasPostViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CitasPostViewModel citasVm)
        {
            if (!_validateUserSession.HasUserAyudante())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            if (!ModelState.IsValid)
            {
                List<PacienteViewModel> pacienteList = await _pacienteServicio.GetAllAsync();
                List<MedicoViewModel> medicoList = await _medicoServicio.GetAllAsync();


                ViewBag.medicos = medicoList;
                ViewBag.pacientes = pacienteList;

                return View(citasVm);
            }
            citasVm.EstadoDelaCita = "Pendiente de Consulta";


            await _citasServicio.AddAsync(citasVm);

            return RedirectToAction("Index", "Citas");
        }
        
        public async Task<IActionResult> CambiarEstado(int Id)
        {
            if (!_validateUserSession.HasUserAyudante())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            var cita = await _citasServicio.GetById(Id);

            await _citasServicio.camibarEstadoCitaCompletado(cita);

            return RedirectToAction("Index", "Citas"); 
        }
    }
}
