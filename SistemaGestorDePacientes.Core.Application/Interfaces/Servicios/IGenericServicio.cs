

namespace SistemaGestorDePacientes.Core.Application.Interfaces.Servicios
{
    public interface IGenericServicio<viewModel, postEntity, Entity> where viewModel : class where postEntity : class where Entity : class
    {
        Task<List<viewModel>> GetAllAsync();
        Task<postEntity>  AddAsync(postEntity entity);
        Task<postEntity> GetById(int Id);
        Task Eliminar(int Id);
        Task Editar(postEntity PostEntity, int Id);
    }
}
