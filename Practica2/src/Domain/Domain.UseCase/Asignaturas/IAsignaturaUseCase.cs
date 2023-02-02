using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCase.Asignaturas
{
    public interface IAsignaturaUseCase
    {
        Task<List<Asignatura>> ObtenerAsignaturas();

        Task<Asignatura> CrearAsignatura(Asignatura asignatura);

        Task<Asignatura> ActualizarAsignatura(Asignatura asignatura);

        Task<Asignatura> ObtenerAsignaturaPorId(string id);

        Task<Asignatura> EliminarAsignatura(string id);
    }
}