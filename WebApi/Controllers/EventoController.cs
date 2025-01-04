using DTOs.EventoDTOs;
using LogicaAplicacion.InterfaceCU.ICUUsuario;
using LogicaNegocio.Entidades;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        ICUListarEventosSegunAtleta _CUListarEventosSegunAtleta;

        public EventoController(ICUListarEventosSegunAtleta cUListarEventosSegunAtleta)
        {
            _CUListarEventosSegunAtleta = cUListarEventosSegunAtleta;
        }



        // GET: api/<EventoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        
        //Evento para traer los eventos en base un atleta

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                List<DtoListarEventos> eventos = _CUListarEventosSegunAtleta.ListarEventosAtleta(id);
                return Ok(eventos);
            }
            catch (Exception ex) 
            {
                List<DtoListarEventos> eventos = _CUListarEventosSegunAtleta.ListarEventosAtleta(id);
                return Ok(eventos);
            }
            
        }

        // POST api/<EventoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EventoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EventoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
