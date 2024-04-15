using Microsoft.AspNetCore.Mvc;
using Sistema_gestor_de_pacientes.Middlewares;
using SistemaGestorDePacientes.Core.Application.Interfaces.Servicios;
using SistemaGestorDePacientes.Core.Application.ViewModel.MedicoViewModel;
using SistemeGestorDePacientes.Core.Entities;

namespace Sistema_gestor_de_pacientes.Controllers
{
    public class MedicoController : Controller
    {
        private readonly IMedicoServicio _medicoServicio;
        private readonly ValidateUserSession _validateUserSession;
        public MedicoController(IMedicoServicio medicoServicio, ValidateUserSession userSession)
        {
            _medicoServicio = medicoServicio;   
            _validateUserSession = userSession;
        }
        public async Task <IActionResult> Index()
        {
            if (!_validateUserSession.HasUserAdmin())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            var medicos = await _medicoServicio.GetAllAsync();

            return View(medicos);
        }

        public IActionResult Create()
        {
            if (!_validateUserSession.HasUserAdmin())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            return View(new MedicoPostViewModel());
        }

        [HttpPost]
        public async Task <IActionResult> Create(MedicoPostViewModel medicoVm)
        {
            if (!_validateUserSession.HasUserAdmin())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            if (!ModelState.IsValid)
            {
                return View(medicoVm);
            }
            
            MedicoPostViewModel medico = await _medicoServicio.AddAsync(medicoVm);

            if(medico != null && medico.Id != 0) 
            {
                medico.ImgUrl = UploadFile(medicoVm.File, medico.Id);

                await _medicoServicio.Editar(medico,medico.Id);
            }

            return RedirectToAction("Index", "Medico");
        }


       public async Task <IActionResult> Editar(int Id)
        {

            if (!_validateUserSession.HasUserAdmin())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            var medico = await _medicoServicio.GetById(Id);

            return View("Create", medico);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(MedicoPostViewModel Vm)
        {

            if (!_validateUserSession.HasUserAdmin())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            if (!ModelState.IsValid)
            {
                return View("Create", Vm);
            }

            MedicoPostViewModel medicoVm = await _medicoServicio.GetById(Vm.Id);

            Vm.ImgUrl = UploadFile(Vm.File, medicoVm.Id, true, medicoVm.ImgUrl);

            await _medicoServicio.Editar(Vm, Vm.Id);

            return RedirectToAction("Index", "Medico");

        }
        public async Task<IActionResult> Eliminar(int Id)
        {

            if (!_validateUserSession.HasUserAdmin())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            return View(await _medicoServicio.GetById(Id));
        }

        [HttpPost]
        public async Task<IActionResult> EliminarMedico(int Id)
        {
            if (!_validateUserSession.HasUserAdmin())
            {
                return RedirectToAction("CerrarSesion", "Usuario");
            }

            await _medicoServicio.Eliminar(Id);

            //Get Directory Path
            string BasePath = $"/img/medicos/{Id}";
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


            return RedirectToRoute(new { Controller = "Medico", Action = "Index" });
        }
        private string UploadFile(IFormFile file, int Id, bool isEditMode = false, string imageURL = "")
        {
            if (isEditMode && file == null)
            {
                return imageURL;
            }

            //Get Directory Path
            string BasePath = $"/img/medicos/{Id}";
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
