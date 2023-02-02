using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Entities.Gateway
{
    /// <summary>
    /// IAsignaturaRepository interface
    /// </summary>
    public interface IAsignaturaRepository
    {
        /// <summary>
        /// Obtener todas las asignaturas
        /// </summary>
        /// <returns></returns>
        Task<List<Asignatura>> ObtenerAsignaturasAsync();

        // <summary>
        /// Crear asignatura
        /// </summary>
        /// <param name="asignatura"></param>
        /// <returns></returns>
        Task<Asignatura> CrearAsignaturaAsync(Asignatura asignatura);

        Task<Asignatura> ActualizarAsignatura(Asignatura asignatura);

        Task<Asignatura> ObtenerAsignaturaPorId(string id);

        Task<Asignatura> EliminarAsignatura(string id);
    }
}