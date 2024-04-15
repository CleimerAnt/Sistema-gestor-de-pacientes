using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaGestorDePacientes.Core.Application.Interfaces.Servicios;
using SistemaGestorDePacientes.Core.Application.Servicios;
using System.Reflection;

namespace SistemaGestorDePacientes.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplucationLayer(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient<IMedicoServicio, MedicoServicio>();

            services.AddTransient<IUsuarioServicio, UsuarioServicio>();

            services.AddTransient<IPacienteServicio, PacienteServicio>();

            services.AddTransient<IPruebasLaboratorioServicio, PruebasLaboratorioServicio>();

            services.AddTransient<ICitasServicio, CitasServicio>();

            services.AddTransient<IResultadoPruebaServicio, ResultadosPruebaServicio>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
