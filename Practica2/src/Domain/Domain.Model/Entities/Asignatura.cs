using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Entities
{
    /// <summary>
    /// Asignatura
    /// </summary>
    public class Asignatura
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Valor Nombre
        /// </summary>
        public string Nombre { get; private set; }

        /// <summary>
        /// Número de créditos
        /// </summary>
        public int Creditos { get; private set; }

        /// <summary>
        /// Nombre del profesor
        /// </summary>
        public string Profesor { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="creditos"></param>
        /// <param name="profesor"></param>
        public Asignatura(string id, string nombre, int creditos, string profesor)
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
        public Asignatura(string nombre, int creditos, string profesor)
        {
            Nombre = nombre;
            Creditos = creditos;
            Profesor = profesor;
        }
    }
}