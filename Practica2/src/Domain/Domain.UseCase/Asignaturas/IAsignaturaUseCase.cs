using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCase.Asignaturas
{
    /// <summary>
    /// Asignatura UseCase
    /// </summary>
    public interface IAsignaturaUseCase
    {
        /// <summary>
        /// Obtener todas las asignaturas
        /// </summary>
        /// <returns></returns>
        Task<List<Asignatura>> ObtenerAsignaturas();

        /// <summary>
        /// Crear asignatura
        /// </summary>
        /// <param name="asignatura"></param>
        /// <returns></returns>
        Task<Asignatura> CrearAsignatura(Asignatura asignatura);

        /// <summary>
        /// Actualizar asignatura
        /// </summary>
        /// <param name="asignatura"></param>
        /// <returns></returns>
        Task<Asignatura> ActualizarAsignatura(Asignatura asignatura);

        /// <summary>
        /// Obtener una asignatura por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Asignatura> ObtenerAsignaturaPorId(string id);

        /// <summary>
        /// Eliminar una asignatura
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Asignatura> EliminarAsignatura(string id);
    }
}