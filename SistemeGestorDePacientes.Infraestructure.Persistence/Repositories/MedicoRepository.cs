using SistemaGestorDePacientes.Core.Application.Interfaces.IRepository;
using SistemeGestorDePacientes.Core.Entities;
using SistemeGestorDePacientes.Infraestructure.Persistence.Context;


namespace SistemeGestorDePacientes.Infraestructure.Persistence.Repositories
{
    public class MedicoRepository : GenericRepository<Medico>, IMedicoRepository
    {
        private readonly ApplicationContext _Context;
        public MedicoRepository(ApplicationContext context) : base(context)
        {
            _Context = context;
        }
    }
}
