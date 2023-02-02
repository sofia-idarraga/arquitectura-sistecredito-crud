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
    public class AsignaturaRepository : IAsignaturaRepository
    {
        private readonly IMongoCollection<AsignaturaEntity> _collectionAsignaturas;

        public AsignaturaRepository(IContext mongodb)
        {
            _collectionAsignaturas = mongodb.Asignaturas;
        }

        public async Task<Asignatura> ActualizarAsignatura(Asignatura asignatura)
        {
            AsignaturaEntity asignaturaEntity =
                new(asignatura.Id, asignatura.Nombre, asignatura.Creditos, asignatura.Profesor);
            var filter = Builders<AsignaturaEntity>.Filter.Eq(a => a.Id, asignatura.Id);
            await _collectionAsignaturas.ReplaceOneAsync(filter, asignaturaEntity);
            return asignatura;
        }

        public async Task<Asignatura> CrearAsignaturaAsync(Asignatura asignatura)
        {
            AsignaturaEntity asignaturaEntity =
                new(asignatura.Nombre, asignatura.Creditos, asignatura.Profesor);
            await _collectionAsignaturas.InsertOneAsync(asignaturaEntity);
            return asignaturaEntity.AsDomainEntity();
        }

        public async Task<Asignatura> EliminarAsignatura(string id)
        {
            var filter = Builders<AsignaturaEntity>.Filter.Eq(a => a.Id, id);
            var result = await _collectionAsignaturas.FindOneAndDeleteAsync(filter);
            return result.AsDomainEntity();
        }

        public async Task<Asignatura> ObtenerAsignaturaPorId(string id)
        {
            var filter = Builders<AsignaturaEntity>.Filter.Eq(a => a.Id, id);
            var result = await _collectionAsignaturas.Find(filter).FirstOrDefaultAsync();
            return result.AsDomainEntity();
        }

        public async Task<List<Asignatura>> ObtenerAsignaturasAsync()
        {
            IAsyncCursor<AsignaturaEntity> asignaturas = await _collectionAsignaturas.FindAsync(Builders<AsignaturaEntity>.Filter.Empty);

            List<Asignatura> asignatutasDomain = asignaturas.ToEnumerable().Select(asignatura => asignatura.AsDomainEntity()).ToList();
            return asignatutasDomain;
        }
    }
}