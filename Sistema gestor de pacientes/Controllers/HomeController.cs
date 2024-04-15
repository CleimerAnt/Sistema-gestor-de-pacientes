using Microsoft.AspNetCore.Mvc;
using Sistema_gestor_de_pacientes.Models;
using SistemaGestorDePacientes.Core.Application.Interfaces;
using SistemaGestorDePacientes.Core.Application.Interfaces.Servicios;
using SistemaGestorDePacientes.Core.Application.Servicios;
using System.Diagnostics;

namespace Sistema_gestor_de_pacientes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsuarioServicio _usuarioServicio;

        public HomeController(ILogger<HomeController> logger, IUsuarioServicio usuarioServicio)
        {
            _logger = logger;
            _usuarioServicio = usuarioServicio;
        }

        public async Task <IActionResult> Index()
        {
          
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
