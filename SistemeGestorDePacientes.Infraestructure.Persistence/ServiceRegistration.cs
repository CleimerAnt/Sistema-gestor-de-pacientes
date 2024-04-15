using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaGestorDePacientes.Core.Application.Interfaces.IRepository;
using SistemeGestorDePacientes.Infraestructure.Persistence.Context;
using SistemeGestorDePacientes.Infraestructure.Persistence.Repositories;


namespace SistemeGestorDePacientes.Infraestructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region "Context"
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("conexion"), m => 
                m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName));
            });
            #endregion

            #region"Repositories"
            services.AddTransient(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));

            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IMedicoRepository, MedicoRepository>();
            services.AddTransient<IPacienteRepository, PacienteRepository>();
            services.AddTransient<IPruebasLaboratorioRepository, PruebasLaboratorioRepository>();
            services.AddTransient<ICitasRepository, CitasRepository>();
            services.AddTransient<IResultadosPruebaRepository, ResultadosPruebaRepository>();
            #endregion
        }
    }
}
