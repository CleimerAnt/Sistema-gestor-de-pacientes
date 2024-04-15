using AutoMapper;
using SistemaGestorDePacientes.Core.Application.Interfaces.IRepository;
using SistemaGestorDePacientes.Core.Application.Interfaces.Servicios;
using SistemaGestorDePacientes.Core.Application.ViewModel;
using SistemaGestorDePacientes.Core.Application.ViewModel.UsuarioViewModel;
using SistemeGestorDePacientes.Core.Entities;


namespace SistemaGestorDePacientes.Core.Application.Servicios
{
    public class UsuarioServicio : GeneralServicio<UsuarioViewModel, UsuarioPostViewModel, Usuario>, IUsuarioServicio
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public UsuarioServicio(IUsuarioRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _usuarioRepository = repository;
            _mapper = mapper;
        }
       
        public async Task<UsuarioViewModel> Login(LoginViewModel LoginVm)
        {
            Usuario Usuarios = await _usuarioRepository.Login(LoginVm);

            if(Usuarios  ==  null)
            {
                return null;
            }

              UsuarioViewModel usuario = new();
              usuario.Id = Usuarios.Id;
              usuario.NombreDeUsuario = Usuarios.Nombre;
              usuario.Contraseña = Usuarios.Contraseña;

            usuario.TipoUsuario = Usuarios.TipoUsuario.ToString();

            return usuario;
        }
       
    }
}
