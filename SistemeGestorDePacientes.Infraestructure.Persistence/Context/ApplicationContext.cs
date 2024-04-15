
using Microsoft.EntityFrameworkCore;
using SistemeGestorDePacientes.Core.Commons;
using SistemeGestorDePacientes.Core.Entities;

namespace SistemeGestorDePacientes.Infraestructure.Persistence.Context
{
    public class ApplicationContext : DbContext 
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Citas> citas { get; set; }
        public DbSet<Medico> medicos { get; set; }
        public DbSet<Pacientes> pacientes { get; set; }
        public DbSet<PruebasLaboratorio> pruebasLaboratorio { get; set; }  
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<ResultadosDeLaboratorio> resultadosDeLaboratorios { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableDaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = "DefauldAppUser";
                        break;

                    case EntityState.Modified:
                        entry.Entity.LasModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = "DefauldAppUser";
                        break;
                }

            }
            return base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region "Tables"
            modelBuilder.Entity<Citas>().ToTable("Citas");
            modelBuilder.Entity<Medico>().ToTable("Medicos");
            modelBuilder.Entity<Pacientes>().ToTable("Pacientes");
            modelBuilder.Entity<PruebasLaboratorio>().ToTable("PruebasLaboratorio");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<ResultadosDeLaboratorio>().ToTable("ResultadosDeLaboratorio");
            #endregion

            #region "Llaves Primarias"
            modelBuilder.Entity<Citas>().HasKey(c => c.Id);
            modelBuilder.Entity<Medico>().HasKey(m => m.Id);
            modelBuilder.Entity<Pacientes>().HasKey(p => p.Id);
            modelBuilder.Entity<PruebasLaboratorio>().HasKey(p => p.Id);
            modelBuilder.Entity<Usuario>().HasKey(u => u.Id);
            modelBuilder.Entity<ResultadosDeLaboratorio>().HasKey(r => r.Id);
            modelBuilder.Entity<ResultadosDeLaboratorio>()
             .Property(r => r.Id)
            .ValueGeneratedOnAdd();
            #endregion

            #region "Relaciones"

            #region "Pacientes"
            modelBuilder.Entity<Pacientes>().HasMany<Citas>(p => p.Citas).WithOne(c => c.pacientes)
              .HasForeignKey(c => c.PacienteId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Pacientes>().HasMany(p => p.resultadosDeLaboratorios).WithOne(r => r.Pacientes)
                .HasForeignKey(r => r.pacienteId).OnDelete(DeleteBehavior.NoAction);


            #endregion

            #region "Pruebas de Laboratorio"

            modelBuilder.Entity<PruebasLaboratorio>().HasMany(p => p.resultadosDeLaboratorios).WithOne(r => r.PruebasLaboratorio)
            .HasForeignKey(r => r.pruebaLaboratorioId).OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region "Medico"
            modelBuilder.Entity<Medico>().HasMany<Citas>(m => m.Citas).WithOne(c => c.medico)
                .HasForeignKey(c => c.MedicoId).OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region "Citas"
            modelBuilder.Entity<Citas>().HasMany(c => c.resultadosDeLaboratorios).WithOne(r => r.citas)
                 .HasForeignKey(r => r.citaId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity <ResultadosDeLaboratorio>()
       .HasOne(r => r.citas)
       .WithMany(c => c.resultadosDeLaboratorios)
       .HasForeignKey(r => r.citaId)
       .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #endregion

            #region "Configuracion de Propiedades"

            #region "Usuario"
            modelBuilder.Entity<Usuario>().Property(u => u.Nombre).IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.Apellido).IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.Correo).IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.NombreDeUsuario).IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.Contraseña).IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.TipoUsuario).IsRequired();
            #endregion

            #region "Citas"
            modelBuilder.Entity<Citas>().Property(c => c.HoraCita).HasColumnType("time");
            #endregion

            #region "Medico"
            modelBuilder.Entity<Medico>().Property(m => m.Nombre).IsRequired();
            modelBuilder.Entity<Medico>().Property(m => m.Apellido).IsRequired();
            modelBuilder.Entity<Medico>().Property(m => m.Correo).IsRequired();
            modelBuilder.Entity<Medico>().Property(m => m.Telefono).IsRequired();
            modelBuilder.Entity<Medico>().Property(m => m.Cedula).IsRequired();
            modelBuilder.Entity<Medico>().Property(m => m.ImgUrl).IsRequired(false);
            #endregion

            #region "Pruebas de Laboratorio"
            modelBuilder.Entity<PruebasLaboratorio>().Property(p => p.NombreDeLaPrueba).IsRequired();
          
           
            #endregion

            #region "Pacientes"
            modelBuilder.Entity<Pacientes>().Property(p => p.Nombre).IsRequired();
            modelBuilder.Entity<Pacientes>().Property(p => p.Apellido).IsRequired();
            modelBuilder.Entity<Pacientes>().Property(p => p.Telefono).IsRequired();
            modelBuilder.Entity<Pacientes>().Property(p => p.Direccion).IsRequired();
            modelBuilder.Entity<Pacientes>().Property(p => p.Cedula).IsRequired();
            modelBuilder.Entity<Pacientes>().Property(p => p.FechaDeNacimiento).IsRequired();
            modelBuilder.Entity<Pacientes>().Property(p => p.EsFumador).IsRequired();
            modelBuilder.Entity<Pacientes>().Property(p => p.TieneAlergias).IsRequired();
            modelBuilder.Entity<Pacientes>().Property(p => p.ImgUrl).IsRequired(false);
            #endregion

            #region "Resultados de Laboratorio"
            modelBuilder.Entity<ResultadosDeLaboratorio>().Property(r => r.pacienteId).IsRequired();
            modelBuilder.Entity<ResultadosDeLaboratorio>().Property(r => r.pruebaLaboratorioId).IsRequired();   
            #endregion

            #endregion

        }

    }
}
