using AutoMapper;
using SistemaGestorDePacientes.Core.Application.ViewModel.CitasViewModel;
using SistemaGestorDePacientes.Core.Application.ViewModel.MedicoViewModel;
using SistemaGestorDePacientes.Core.Application.ViewModel.PacientesViewModel;
using SistemaGestorDePacientes.Core.Application.ViewModel.PruebasLaboratorioViewModel;
using SistemaGestorDePacientes.Core.Application.ViewModel.ResultadosPruebaViewModel;
using SistemaGestorDePacientes.Core.Application.ViewModel.UsuarioViewModel;
using SistemeGestorDePacientes.Core.Entities;


namespace SistemaGestorDePacientes.Core.Application.Mapings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Citas, CitasViewModel>()
                .ForMember(dest => dest.PacienteNombre, opt => opt.Ignore()
                ).ForMember(dest => dest.MedicoNombre, opt => opt.Ignore()
                ).ReverseMap()
                .ForMember(dest => dest.Created, opt => opt.Ignore()
                ).ForMember(dest => dest.CreatedBy, opt => opt.Ignore()
                ).ForMember(dest => dest.LasModified, opt => opt.Ignore()
                ).ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());


            CreateMap<Citas, CitasPostViewModel>()
                .ReverseMap()
                .ForMember(dest => dest.Created, opt => opt.Ignore()
                ).ForMember(dest => dest.CreatedBy, opt => opt.Ignore()
                ).ForMember(dest => dest.LasModified, opt => opt.Ignore()
                ).ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Medico, MedicoViewModel>()
                .ForMember(dest => dest.file, opt => opt.Ignore())
                .ReverseMap()
                 .ForMember(dest => dest.Created, opt => opt.Ignore()
                ).ForMember(dest => dest.CreatedBy, opt => opt.Ignore()
                ).ForMember(dest => dest.LasModified, opt => opt.Ignore()
                ).ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Medico, MedicoPostViewModel>()
                .ForMember(dest => dest.File, opt => opt.Ignore())
                .ReverseMap()
                 .ForMember(dest => dest.Created, opt => opt.Ignore()
                ).ForMember(dest => dest.CreatedBy, opt => opt.Ignore()
                ).ForMember(dest => dest.LasModified, opt => opt.Ignore()
                ).ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Pacientes, PacienteViewModel>()
                .ReverseMap()
                 .ForMember(dest => dest.Created, opt => opt.Ignore()
                ).ForMember(dest => dest.CreatedBy, opt => opt.Ignore()
                ).ForMember(dest => dest.LasModified, opt => opt.Ignore()
                ).ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Pacientes, PacientePostViewModel>()
                .ForMember(dest => dest.File, opt => opt.Ignore())
                .ReverseMap()
                 .ForMember(dest => dest.Created, opt => opt.Ignore()
                ).ForMember(dest => dest.CreatedBy, opt => opt.Ignore()
                ).ForMember(dest => dest.LasModified, opt => opt.Ignore()
                ).ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());

            CreateMap<PruebasLaboratorio, PruebasLaboratioViewModel>()
              .ReverseMap()
               .ForMember(dest => dest.Created, opt => opt.Ignore()
              ).ForMember(dest => dest.CreatedBy, opt => opt.Ignore()
              ).ForMember(dest => dest.LasModified, opt => opt.Ignore()
              ).ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());

            CreateMap<PruebasLaboratorio, PruebaLaboratorioPostViewModel>()
             .ReverseMap()
              .ForMember(dest => dest.Created, opt => opt.Ignore()
             ).ForMember(dest => dest.CreatedBy, opt => opt.Ignore()
             ).ForMember(dest => dest.LasModified, opt => opt.Ignore()
             ).ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());

            CreateMap<ResultadosDeLaboratorio, ResultadosPruebaViewModel>()
                .ForMember(dest => dest.pacienteNombre, opt => opt.Ignore())
                .ForMember(dest => dest.pacienteApellido, opt => opt.Ignore())
                .ForMember(dest => dest.pacienteCedula, opt => opt.Ignore())
                .ForMember(dest => dest.pruebaLaboratorioNombre, opt => opt.Ignore())
             .ReverseMap()
              .ForMember(dest => dest.Created, opt => opt.Ignore()
             ).ForMember(dest => dest.CreatedBy, opt => opt.Ignore()
             ).ForMember(dest => dest.LasModified, opt => opt.Ignore()
             ).ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());

            CreateMap<ResultadosDeLaboratorio, ResultadosPruebaPostViewModel>()
                .ForMember(dest => dest.opciones, opt => opt.Ignore())
             .ReverseMap()
              .ForMember(dest => dest.Created, opt => opt.Ignore()
             ).ForMember(dest => dest.CreatedBy, opt => opt.Ignore()
             ).ForMember(dest => dest.LasModified, opt => opt.Ignore()
             ).ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Usuario, UsuarioViewModel>()
           .ReverseMap()
            .ForMember(dest => dest.Created, opt => opt.Ignore()
           ).ForMember(dest => dest.CreatedBy, opt => opt.Ignore()
           ).ForMember(dest => dest.LasModified, opt => opt.Ignore()
           ).ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Usuario, UsuarioPostViewModel>()
            .ForMember(dest => dest.ConfirmarContraseña, opt => opt.Ignore())
          .ReverseMap()
           .ForMember(dest => dest.Created, opt => opt.Ignore()
          ).ForMember(dest => dest.CreatedBy, opt => opt.Ignore()
          ).ForMember(dest => dest.LasModified, opt => opt.Ignore()
          ).ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());

        }
    }
}
