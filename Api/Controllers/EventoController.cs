using DTOs.EventoDTOs;
using LogicaAplicacion.InterfaceCU.ICUUsuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
            private readonly ICUFiltrarEventos _filtrarEventos;

            public EventoController(ICUFiltrarEventos filtrar)
            {
                _filtrarEventos = filtrar;
            }


            [HttpGet("Filtrar")]
        [Authorize(Roles = "Digitador")]
        public IActionResult GetFiltroEventos(
            [FromQuery] int? disciplinaId,
            [FromQuery] DateTime? fechaInicio,
            [FromQuery] DateTime? fechaFin,
            [FromQuery] string? nombreEvento,
            [FromQuery] int? puntajeMin,
            [FromQuery] int? puntajeMax)
            {
                try
                {
                    var eventos = _filtrarEventos.EjecutarListarEventos(disciplinaId, fechaInicio, fechaFin, nombreEvento, puntajeMin, puntajeMax);
                    return Ok(eventos);
                }
                catch (Exception ex)
                {
                    return NotFound(new { mensaje = ex.Message });
                }
            }






        
    }
}
