using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoints.ReactiveWeb.Entity
{
    public class AsignaturaRequest
    {
        public string Nombre { get; set; }
        public int Creditos { get; set; }
        public string Profesor { get; set; }

        public Asignatura AsDomainEntity() => new(Nombre, Creditos, Profesor);
    }
}