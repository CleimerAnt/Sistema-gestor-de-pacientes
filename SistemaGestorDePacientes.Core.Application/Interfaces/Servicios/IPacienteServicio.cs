using SistemaGestorDePacientes.Core.Application.ViewModel.PacientesViewModel;
using SistemeGestorDePacientes.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestorDePacientes.Core.Application.Interfaces.Servicios
{
    public interface IPacienteServicio : IGenericServicio<PacienteViewModel, PacientePostViewModel, Pacientes>
    {
    }
}
