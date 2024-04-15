
using SistemaGestorDePacientes.Core.Application.Interfaces.IRepository;
using SistemeGestorDePacientes.Core.Entities;
using SistemeGestorDePacientes.Infraestructure.Persistence.Context;


namespace SistemeGestorDePacientes.Infraestructure.Persistence.Repositories
{
    public class PruebasLaboratorioRepository : GenericRepository<PruebasLaboratorio>, IPruebasLaboratorioRepository
    {
        private readonly ApplicationContext _Context;
        public PruebasLaboratorioRepository(ApplicationContext context): base(context)
        {
            _Context = context;
        }
    }
}
