
using SistemaGestorDePacientes.Core.Application.Interfaces.IRepository;
using SistemaGestorDePacientes.Core.Application.ViewModel.ResultadosPruebaViewModel;
using SistemeGestorDePacientes.Core.Entities;
using SistemeGestorDePacientes.Infraestructure.Persistence.Context;


namespace SistemeGestorDePacientes.Infraestructure.Persistence.Repositories
{
    public class ResultadosPruebaRepository : GenericRepository<ResultadosDeLaboratorio>, IResultadosPruebaRepository
    {
        private ApplicationContext _Context;
        public ResultadosPruebaRepository(ApplicationContext context) : base(context)
        {
            _Context = context;
        }
        public async Task<List<ResultadosPruebaViewModel>> GetForCedula(string cedula)
        {
            var modelo = from r in _Context.resultadosDeLaboratorios
                         join p in _Context.pacientes on r.pacienteId equals p.Id
                         join pr in _Context.pruebasLaboratorio on r.pruebaLaboratorioId equals pr.Id
                         where p.Cedula == cedula
                         where r.EstadoPrueba == "pendiente"
                         select new ResultadosPruebaViewModel
                         {
                             pacienteCedula = p.Cedula,
                             pacienteNombre = p.Nombre,
                             pacienteApellido = p.Apellido,
                             Id = r.Id,
                             pruebaLaboratorioNombre = pr.NombreDeLaPrueba,
                             CitasId = r.citaId
                         };
            return modelo.ToList();
        }
        public async Task<List<ResultadosPruebaViewModel>> GetAllAsyncLINQ()
        {
            var modelo = from r in _Context.resultadosDeLaboratorios
                         join p in _Context.pacientes on r.pacienteId equals p.Id
                         join pr in _Context.pruebasLaboratorio on r.pruebaLaboratorioId equals pr.Id
                         where r.EstadoPrueba == "pendiente"
                         select new ResultadosPruebaViewModel
                         {
                             Id = r.Id,
                             pacienteId = p.Id,
                             pruebaLaboratorioId = p.Id,
                             pruebaLaboratorioNombre = pr.NombreDeLaPrueba,
                             pacienteNombre = p.Nombre,
                             pacienteApellido = p.Apellido,
                             pacienteCedula = p.Cedula,
                             CitasId = r.citaId
                         };

            return modelo.ToList();
        }

        public async Task<List<ResultadosPruebaViewModel>> GetAllAsyncCitaCompletada(int Id)
        {
            var modelo = from r in _Context.resultadosDeLaboratorios
                         join p in _Context.pacientes on r.pacienteId equals p.Id
                         join pr in _Context.pruebasLaboratorio on r.pruebaLaboratorioId equals pr.Id
                         where r.EstadoPrueba == "Completada"
                         where r.citaId == Id
                         select new ResultadosPruebaViewModel
                         {
                             Id = r.Id,
                             pacienteId = p.Id,
                             pruebaLaboratorioId = p.Id,
                             pruebaLaboratorioNombre = pr.NombreDeLaPrueba,
                             pacienteNombre = p.Nombre,
                             pacienteApellido = p.Apellido,
                             pacienteCedula = p.Cedula,
                             ResultadoPrueba = r.ResultadoPrueba
                         };

            return modelo.ToList();
        }

        public async Task<List<ResultadosPruebaViewModel>> GetPruebaForCita(int Id)
        {
           

            var modelo = (from r in _Context.resultadosDeLaboratorios  
                              join p in _Context.pruebasLaboratorio on r.pruebaLaboratorioId equals p.Id
                              where r.citaId == Id
                              select new ResultadosPruebaViewModel
                              {
                                  pruebaLaboratorioNombre = p.NombreDeLaPrueba,
                                  EstadoPrueba = r.EstadoPrueba,
                                  CitasId = r.citaId
                              }).ToList();




            return modelo.ToList();
        }
    }
}
