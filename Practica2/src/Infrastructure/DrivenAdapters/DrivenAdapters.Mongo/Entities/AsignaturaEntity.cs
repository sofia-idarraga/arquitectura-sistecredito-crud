using Domain.Model.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Linq;

namespace DrivenAdapters.Mongo.Entities
{
    public class AsignaturaEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// Nombre
        /// </summary>
        [BsonElement(elementName: "nombre")]
        public string Nombre { get; set; }

        /// <summary>
        /// Número de créditos
        /// </summary>
        [BsonElement(elementName: "creditos")]
        public int Creditos { get; private set; }

        /// <summary>
        /// Nombre del profesor
        /// </summary>
        [BsonElement(elementName: "profesor")]
        public string Profesor { get; private set; }

        public Asignatura AsDomainEntity() => new(Id, Nombre, Creditos, Profesor);

        public AsignaturaEntity(string id, string nombre, int creditos, string profesor)
        {
            Id = id;
            Nombre = nombre;
            Creditos = creditos;
            Profesor = profesor;
        }

        public AsignaturaEntity(string nombre, int creditos, string profesor)
        {
            Nombre = nombre;
            Creditos = creditos;
            Profesor = profesor;
        }
    }
}