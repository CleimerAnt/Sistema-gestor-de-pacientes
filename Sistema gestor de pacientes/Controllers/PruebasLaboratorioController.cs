using Microsoft.AspNetCore.Mvc;
using Sistema_gestor_de_pacientes.Middlewares;
using SistemaGestorDePacientes.Core.Application.Interfaces.Servicios;

using SistemaGestorDePacientes.Core.Application.ViewModel.PruebasLaboratorioViewModel;


namespace Sistema_gestor_de_pacientes.Controllers
{
    public class PruebasLaboratorioController : Controller
    {
        private readonly IPruebasLaboratorioServicio _pruebas;
        private readonly ValidateUserSession _validateUserSession;
        public PruebasLaboratorioController(IPruebasLaboratorioServicio pruebas, ValidateUserSession validateUserSession)
        {
            _pruebas = pruebas;
            _validateUserSession = validateUserSession; 
        }
        public async Task <IActionResult> Index()
        {
            if (!_validateUserSession.HasUserAdmin())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            var pruebas = await _pruebas.GetAllAsync(); 

            return View(pruebas);
        }

        public async Task<IActionResult> Eliminar(int Id)
        {
            if (!_validateUserSession.HasUserAdmin())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            return View("Eliminar", await _pruebas.GetById(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(PruebaLaboratorioPostViewModel pruebasVm)
        {
            if (!_validateUserSession.HasUserAdmin())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            await _pruebas.Eliminar(pruebasVm.Id);

            return RedirectToAction("Index", "PruebasLaboratorio");
        }


        public async Task<IActionResult> Editar(int Id)
        {
            if (!_validateUserSession.HasUserAdmin())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            return View("Create", await _pruebas.GetById(Id));

        }

        [HttpPost]
        public async Task<IActionResult> Editar(PruebaLaboratorioPostViewModel prueba)
        {
            if (!_validateUserSession.HasUserAdmin())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            if (!ModelState.IsValid)
            {
                return View("Create", prueba);
            }

            await _pruebas.Editar(prueba, prueba.Id);

            return RedirectToAction("Index", "PruebasLaboratorio");
        }

        public IActionResult Create()
        {
            if (!_validateUserSession.HasUserAdmin())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            return View(new PruebaLaboratorioPostViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(PruebaLaboratorioPostViewModel pruebaVm)
        {
            if (!_validateUserSession.HasUserAdmin())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            if (!ModelState.IsValid)
            {
                return View(pruebaVm);
            }

             await _pruebas.AddAsync(pruebaVm);

            return RedirectToAction("Index", "PruebasLaboratorio");
        }


    }
}
