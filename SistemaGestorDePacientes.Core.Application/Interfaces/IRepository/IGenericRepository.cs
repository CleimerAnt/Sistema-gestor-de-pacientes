
namespace SistemaGestorDePacientes.Core.Application.Interfaces.IRepository
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        Task<List<Entity>> GetAllAsync();
        Task<Entity> GetByIdAsync(int Id);
        Task<Entity> AddAsync(Entity entity);
        Task Remove(Entity entity);
        Task UpdateAsync(Entity entity, int Id);

    }
}
