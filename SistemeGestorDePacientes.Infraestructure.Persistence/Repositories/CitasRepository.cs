using Microsoft.EntityFrameworkCore;
using SistemaGestorDePacientes.Core.Application.Interfaces.IRepository;
using SistemaGestorDePacientes.Core.Application.ViewModel.CitasViewModel;
using SistemeGestorDePacientes.Core.Entities;
using SistemeGestorDePacientes.Infraestructure.Persistence.Context;


namespace SistemeGestorDePacientes.Infraestructure.Persistence.Repositories
{
    public class CitasRepository : GenericRepository<Citas>, ICitasRepository 
    {
        private readonly ApplicationContext _context;
        public CitasRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

       public async Task <List<CitasViewModel>> GetAllLINQ()
        {
            var modelos = from c in _context.citas
                          join p in _context.pacientes on c.PacienteId equals p.Id
                          join m in _context.medicos on c.MedicoId equals m.Id
                          select new CitasViewModel
                          {
                              Id = c.Id,
                              PacienteId = c.PacienteId,
                              MedicoId = c.MedicoId,
                              FechaCita = c.FechaCita,
                              HoraCita = c.HoraCita,
                              CausaDeLaCita = c.CausaDeLaCita,
                              EstadoDelaCita = c.EstadoDelaCita,
                              MedicoNombre = m.Nombre,
                              PacienteNombre = p.Nombre,
                          };

            return await modelos.ToListAsync();
        }
    }
}
