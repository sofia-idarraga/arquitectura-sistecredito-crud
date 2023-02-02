using Domain.Model.Entities;
using Domain.Model.Entities.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCase.Asignaturas
{
    /// <summary>
    /// <see cref="IAsignaturaUseCase"/>
    /// </summary>
    public class AsignaturaUseCase : IAsignaturaUseCase
    {
        private readonly IAsignaturaRepository _asignaturaRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsignaturaUseCase"/> class.
        /// </summary>
        /// <param name="asignaturaRepository">Asignatura Repository.</param>
        public AsignaturaUseCase(IAsignaturaRepository asignaturaRepository)
        {
            _asignaturaRepository = asignaturaRepository;
        }

        /// <summary>
        ///  <see cref="IAsignaturaUseCase.ActualizarAsignatura(Asignatura)"/>
        /// </summary>
        /// <param name="asignatura"></param>
        /// <returns></returns>
        public async Task<Asignatura> ActualizarAsignatura(Asignatura asignatura)
        {
            return await _asignaturaRepository.ActualizarAsignatura(asignatura);
        }

        /// <summary>
        ///  <see cref="IAsignaturaUseCase.CrearAsignatura(Asignatura)"/>
        /// </summary>
        /// <param name="asignatura"></param>
        /// <returns></returns>
        public async Task<Asignatura> CrearAsignatura(Asignatura asignatura)
        {
            return await _asignaturaRepository.CrearAsignaturaAsync(asignatura);
        }

        /// <summary>
        /// <see cref="IAsignaturaUseCase.EliminarAsignatura(string)"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Asignatura> EliminarAsignatura(string id)
        {
            return await _asignaturaRepository.EliminarAsignatura(id);
        }

        /// <summary>
        /// <see cref="IAsignaturaUseCase.ObtenerAsignaturaPorId(string)"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Asignatura> ObtenerAsignaturaPorId(string id)
        {
            return await _asignaturaRepository.ObtenerAsignaturaPorId(id);
        }

        /// <summary>
        /// <see cref="IAsignaturaUseCase.ObtenerAsignaturas()"/>
        /// </summary>
        /// <returns></returns>
        public async Task<List<Asignatura>> ObtenerAsignaturas()
        {
            return await _asignaturaRepository.ObtenerAsignaturasAsync();
        }
    }
}