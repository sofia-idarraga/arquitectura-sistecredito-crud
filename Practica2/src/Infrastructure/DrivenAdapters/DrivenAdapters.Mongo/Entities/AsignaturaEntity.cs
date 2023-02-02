using Domain.Model.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Linq;

namespace DrivenAdapters.Mongo.Entities
{
    /// <summary>
    /// AsignaturaEntity
    /// </summary>
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

        /// <summary>
        /// Transforma Asignatura de DTO a Entidad de Dominio
        /// </summary>
        /// <returns></returns>
        public Asignatura AsDomainEntity() => new(Id, Nombre, Creditos, Profesor);

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="creditos"></param>
        /// <param name="profesor"></param>
        public AsignaturaEntity(string id, string nombre, int creditos, string profesor)
        {
            Id = id;
            Nombre = nombre;
            Creditos = creditos;
            Profesor = profesor;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="creditos"></param>
        /// <param name="profesor"></param>
        public AsignaturaEntity(string nombre, int creditos, string profesor)
        {
            Nombre = nombre;
            Creditos = creditos;
            Profesor = profesor;
        }
    }
}