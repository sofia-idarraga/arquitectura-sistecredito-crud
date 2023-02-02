using Domain.Model.Entities;
using Domain.UseCase.Asignaturas;
using Domain.UseCase.Common;
using EntryPoints.ReactiveWeb.Base;
using EntryPoints.ReactiveWeb.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoints.ReactiveWeb.Controllers
{
    /// <summary>
    /// Asignatura
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class AsignaturaController : AppControllerBase<AsignaturaController>
    {
        private readonly IAsignaturaUseCase _asignaturaUseCase;

        public AsignaturaController(IAsignaturaUseCase asignaturaUseCase, IManageEventsUseCase eventsService) : base(eventsService)
        {
            _asignaturaUseCase = asignaturaUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> CrearAsignatura(AsignaturaRequest asignatura)
        {
            return await HandleRequest(
                async () =>
                {
                    Asignatura nuevaAsignatura = asignatura.AsDomainEntity();
                    return await _asignaturaUseCase.CrearAsignatura(nuevaAsignatura);
                }, ""
                );
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerAsignaturas()
        {
            return await HandleRequest(
                async () =>
                {
                    return await _asignaturaUseCase.ObtenerAsignaturas();
                }, "");
        }

        [HttpPut()]
        public async Task<IActionResult> ActualizarTienda([FromBody] ActualizarAsignaturaRequest asignatura)
        {
            return await HandleRequest(async () =>
            {
                Asignatura asignaturaActualizada = asignatura.AsDomainEntity();
                return await _asignaturaUseCase.ActualizarAsignatura(asignaturaActualizada);
            }, "");
        }

        [HttpGet("/Id")]
        public async Task<IActionResult> ObtenerPorId([FromQuery] string id)
        {
            return await HandleRequest(async () =>
            {
                return await _asignaturaUseCase.ObtenerAsignaturaPorId(id);
            }, "");
        }

        [HttpDelete()]
        public async Task<IActionResult> Eliminar([FromQuery] string id)
        {
            return await HandleRequest(async () =>
            {
                return await _asignaturaUseCase.EliminarAsignatura(id);
            }, "");
        }
    }
}