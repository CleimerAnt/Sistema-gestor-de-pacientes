using Microsoft.EntityFrameworkCore;
using SistemaGestorDePacientes.Core.Application.Helpers;
using SistemaGestorDePacientes.Core.Application.Interfaces.IRepository;

using SistemaGestorDePacientes.Core.Application.ViewModel;
using SistemeGestorDePacientes.Core.Entities;
using SistemeGestorDePacientes.Infraestructure.Persistence.Context;


namespace SistemeGestorDePacientes.Infraestructure.Persistence.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        private readonly ApplicationContext _Context;
        

        public UsuarioRepository(ApplicationContext context) : base(context)
        {
            _Context = context;
        }
        public override Task UpdateAsync(Usuario entity, int Id)
        {
            entity.Contraseña = PasswordEncription.ComputeSha256Hash(entity.Contraseña);
            return base.UpdateAsync(entity, Id);
        }
      
        public override Task<Usuario> AddAsync(Usuario entity)
        {

            entity.Contraseña = PasswordEncription.ComputeSha256Hash(entity.Contraseña);

            return base.AddAsync(entity);
         
        }

        

        public async Task<Usuario> Login(LoginViewModel loginVm)
        {
            string ContraseÑaEncriptada = PasswordEncription.ComputeSha256Hash(loginVm.Contraseña);

            Usuario usuario = await _Context.Set<Usuario>()
                .FirstOrDefaultAsync(u => u.NombreDeUsuario == loginVm.Nombre
                && u.Contraseña == ContraseÑaEncriptada);

            return usuario;
        }
    }
}
