using SistemaGestorDePacientes.Core.Application.Interfaces.IRepository;
using SistemeGestorDePacientes.Core.Entities;
using SistemeGestorDePacientes.Infraestructure.Persistence.Context;

namespace SistemeGestorDePacientes.Infraestructure.Persistence.Repositories
{
    public class PacienteRepository : GenericRepository<Pacientes>, IPacienteRepository
    {
        private readonly ApplicationContext _Context;
        public PacienteRepository(ApplicationContext context): base(context)
        {
            _Context = context;
        }
    }
}
