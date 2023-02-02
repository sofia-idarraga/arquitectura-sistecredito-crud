using Domain.Model.Entities;
using Domain.Model.Entities.Gateway;
using DrivenAdapters.Mongo.Entities;
using MongoDB.Driver;
using MongoDB.Driver.Core.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace DrivenAdapters.Mongo
{
    /// <summary>
    /// Asignatura Repository
    /// </summary>
    public class AsignaturaRepository : IAsignaturaRepository
    {
        private readonly IMongoCollection<AsignaturaEntity> _collectionAsignaturas;

        /// <summary>
        /// Inicializa una instancia de <see cref="AsignaturaRepository"/> class.
        /// </summary>
        /// <param name="mongodb"></param>
        public AsignaturaRepository(IContext mongodb)
        {
            _collectionAsignaturas = mongodb.Asignaturas;
        }

        /// <summary>
        /// <see cref="IAsignaturaRepository.ActualizarAsignatura(Asignatura)"/>
        /// </summary>
        /// <param name="asignatura"></param>
        /// <returns></returns>
        public async Task<Asignatura> ActualizarAsignatura(Asignatura asignatura)
        {
            AsignaturaEntity asignaturaEntity =
                new(asignatura.Id, asignatura.Nombre, asignatura.Creditos, asignatura.Profesor);
            var filter = Builders<AsignaturaEntity>.Filter.Eq(a => a.Id, asignatura.Id);
            await _collectionAsignaturas.ReplaceOneAsync(filter, asignaturaEntity);
            return asignatura;
        }

        /// <summary>
        /// <see cref="IAsignaturaRepository.CrearAsignaturaAsync(Asignatura)"/>
        /// </summary>
        /// <param name="asignatura"></param>
        /// <returns></returns>
        public async Task<Asignatura> CrearAsignaturaAsync(Asignatura asignatura)
        {
            AsignaturaEntity asignaturaEntity =
                new(asignatura.Nombre, asignatura.Creditos, asignatura.Profesor);
            await _collectionAsignaturas.InsertOneAsync(asignaturaEntity);
            return asignaturaEntity.AsDomainEntity();
        }

        /// <summary>
        /// <see cref="IAsignaturaRepository.EliminarAsignatura(string)"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Asignatura> EliminarAsignatura(string id)
        {
            var filter = Builders<AsignaturaEntity>.Filter.Eq(a => a.Id, id);
            var result = await _collectionAsignaturas.FindOneAndDeleteAsync(filter);
            return result.AsDomainEntity();
        }

        /// <summary>
        /// <see cref="IAsignaturaRepository.ObtenerAsignaturaPorId(string)"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Asignatura> ObtenerAsignaturaPorId(string id)
        {
            var filter = Builders<AsignaturaEntity>.Filter.Eq(a => a.Id, id);
            var result = await _collectionAsignaturas.Find(filter).FirstOrDefaultAsync();
            return result.AsDomainEntity();
        }

        /// <summary>
        /// <see cref="IAsignaturaRepository.ObtenerAsignaturasAsync()"/>
        /// </summary>
        /// <returns></returns>
        public async Task<List<Asignatura>> ObtenerAsignaturasAsync()
        {
            IAsyncCursor<AsignaturaEntity> asignaturas = await _collectionAsignaturas.FindAsync(Builders<AsignaturaEntity>.Filter.Empty);

            List<Asignatura> asignatutasDomain = asignaturas.ToEnumerable().Select(asignatura => asignatura.AsDomainEntity()).ToList();
            return asignatutasDomain;
        }
    }
}