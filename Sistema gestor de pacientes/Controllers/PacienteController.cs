using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Extensions;
using Sistema_gestor_de_pacientes.Middlewares;
using SistemaGestorDePacientes.Core.Application.Interfaces.Servicios;
using SistemaGestorDePacientes.Core.Application.ViewModel.PacientesViewModel;
using SistemeGestorDePacientes.Core.Entities;


namespace Sistema_gestor_de_pacientes.Controllers
{
    public class PacienteController : Controller
    {
        private readonly IPacienteServicio _pacienteServicio;
        private readonly ValidateUserSession _validateUserSession;
        public PacienteController(IPacienteServicio pacienteServicio, ValidateUserSession validateUserSession)
        {
            _pacienteServicio = pacienteServicio;
            _validateUserSession = validateUserSession;
        }
        public async Task <IActionResult> Index()
        {
            if (!_validateUserSession.HasUserAyudante())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            var paciente = await _pacienteServicio.GetAllAsync();    

            return View(paciente);
        }
        public IActionResult Create()
        {
            if (!_validateUserSession.HasUserAyudante())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            return View(new PacientePostViewModel());
        }
        [HttpPost]
        public async Task <IActionResult> Create(PacientePostViewModel pacienteVm)
        {
            if (!_validateUserSession.HasUserAyudante())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            if (!ModelState.IsValid)
            {
                return View(pacienteVm);
            }

            PacientePostViewModel paciente = await _pacienteServicio.AddAsync(pacienteVm);

            if (paciente != null && paciente.Id != 0)
            {
                paciente.ImgUrl = UploadFile(pacienteVm.File, paciente.Id);

                await _pacienteServicio.Editar(paciente, paciente.Id);
            }

            return RedirectToAction("Index", "Paciente");
        }

        public async Task<IActionResult> Editar(int Id)
        {
            if (!_validateUserSession.HasUserAyudante())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }
            
            var paciente = await _pacienteServicio.GetById(Id);
      

            return View("Create", paciente);
          
        }

        [HttpPost]
        public async Task<IActionResult> Editar(PacientePostViewModel Vm)
        {
            if (!_validateUserSession.HasUserAyudante())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            if (!ModelState.IsValid)
            {
                return View("Create", Vm);
            }
            
            PacientePostViewModel pacienteVm = await _pacienteServicio.GetById(Vm.Id);

            Vm.ImgUrl = UploadFile(Vm.File, pacienteVm.Id, true, pacienteVm.ImgUrl);

            await _pacienteServicio.Editar(Vm, Vm.Id);

            return RedirectToAction("Index", "Paciente");
           
         
        }

        public async Task<IActionResult> Eliminar(int Id)
        {
            if (!_validateUserSession.HasUserAyudante())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            return View(await _pacienteServicio.GetById(Id));
        }

        [HttpPost]
        public async Task<IActionResult> EliminarPaciente(int Id)
        {
            

            await _pacienteServicio.Eliminar(Id);

            //Get Directory Path
            string BasePath = $"/img/pacientes/{Id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{BasePath}");

            if (Directory.Exists(path))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                foreach (FileInfo file in directoryInfo.GetFiles())
                {
                    file.Delete();
                }

                foreach (DirectoryInfo folder in directoryInfo.GetDirectories())
                {
                    folder.Delete(true);
                }

                Directory.Delete(path);
            }


            return RedirectToRoute(new { Controller = "Paciente", Action = "Index" });
        }



        private string UploadFile(IFormFile file, int Id, bool isEditMode = false, string imageURL = "")
        {
            if (isEditMode && file == null)
            {
                return imageURL;
            }

            //Get Directory Path
            string BasePath = $"/img/pacientes/{Id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{BasePath}");

            //Create Folder if no exits
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }


            //GetFilePath
            Guid guid = Guid.NewGuid();
            FileInfo fileInfo = new(file.FileName);
            string fileName = guid + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            if (isEditMode)
            {
                string[] oldImage = imageURL.Split("/");
                string olImageName = oldImage[^1];
                string completeImageOldPath = Path.Combine(path, olImageName);

                if (System.IO.File.Exists(completeImageOldPath))
                {
                    System.IO.File.Delete(completeImageOldPath);
                }

            };
            return $"{BasePath}/{fileName}";
        }
    }
}
