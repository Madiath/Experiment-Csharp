using DTOs.DisciplinaDTOs;
using LogicaAplicacion.CasosUso.CUUsuario;
using LogicaAplicacion.InterfaceCU.ICUDigitador;
using LogicaAplicacion.InterfaceCU.ICUUsuario;
using LogicaNegocio.Exepciones.ExepcionesDigitador;
using LogicaNegocio.Exepciones.ExepcionesDisciplina;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {
        ICUListarAtletasDisciplina _CUAtletasDisciplina;
        ICUEliminarDisciplina _CUEliminarDisciplina;
        ICUAltaDisciplina _CUAltaDisciplina;
        ICUModificarDisciplina _CUModificarDisciplina;
        ICUListarDisciplinas _CUListarDisciplinas;
        ICUObtenerDisciplinaId _CUObtenerDisciplinaId;
        ICUObtenerDisciplinaNombre _CUObtenerDisciplinaNombre;
        public DisciplinaController(ICUListarAtletasDisciplina icuAtletasDisciplina, 
            ICUEliminarDisciplina cUEliminarDisciplina,
            ICUAltaDisciplina cUAltaDisciplina, ICUModificarDisciplina cUModificarDisciplina, ICUListarDisciplinas cUListarDisciplinas,
            ICUObtenerDisciplinaId obtenerDisciplinaId,ICUObtenerDisciplinaNombre cUObtenerDisciplinaNombre)
        {
            _CUAtletasDisciplina = icuAtletasDisciplina;
            _CUEliminarDisciplina = cUEliminarDisciplina;
            _CUAltaDisciplina = cUAltaDisciplina;
            _CUModificarDisciplina = cUModificarDisciplina;
            _CUListarDisciplinas = cUListarDisciplinas;
            _CUObtenerDisciplinaId = obtenerDisciplinaId;
            _CUObtenerDisciplinaNombre = cUObtenerDisciplinaNombre;
        }

        [HttpGet("ObtenerAtletasByDisciplina/{id}")]
        [Authorize(Roles = "Digitador")]
        public IActionResult ObtenerAtletasByDisciplina(int id)
        {
            try
            {
                return Ok(_CUAtletasDisciplina.ListarAtletasDisciplina(id));
            }
            catch (DisciplinaNoEncontradaException e)
            {
                return NoContent();
            }
            catch (NoAtletasDisciplinaException e)
            {
                return NoContent();
            }
            catch (Exception e)
            {
                return Unauthorized();
            }



        }




        
        [HttpPost("AltaDisciplina")]
        [Authorize(Roles = "Digitador")]
        public IActionResult AltaDisciplina([FromBody] DtoDisciplina dto) 
        {
            try 
            {
                string email = EmailUser();
                _CUAltaDisciplina.AltaDisciplina(dto,email);
                return StatusCode(201, "Alta realizada");
            }
            catch (AgregarDisciplinaNombreYaExisteException e)
            {
                return StatusCode(409, "Ya existe una disciplina con ese nombre");
            }
            catch (AgregarDisciplinaCodigoYaExisteException e)
            {
                return StatusCode(409, "Ya existe una disciplina con ese codigo");
            }
            catch(Exception e) 
            {
             return Unauthorized();
            }
        }

   
        [HttpDelete("EliminarDisciplina/{id}")] 
        [Authorize(Roles = "Digitador")]
        public IActionResult Eliminar(int id) 
        {
            try
            {
                string email = EmailUser();
                _CUEliminarDisciplina.EliminarDisciplina(id,email);
                return NoContent();
            }
            catch(ArgumentException e) 
            {
                return StatusCode(404, e.Message);
            }
            catch (Exception e) 
            {
                return StatusCode(500, e.Message);

            }
        }


        
        [HttpPut("ModificarDisciplina")]
        [Authorize(Roles = "Digitador")]
        public IActionResult Modificar([FromBody] DtoAltaDisciplina dto) 
        {
            try
            {
                string email = EmailUser();
                _CUModificarDisciplina.ModificarDisciplina(dto, email);
                return StatusCode(201, "La disciplina a sido modificada");
            }
            catch (DisciplinaNoEncontradaException e) 
            {
                return StatusCode(404, "No se encontro la disciplina tanto por el nombre u el codigo");
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        
        [HttpGet("ObtenerDisciplinas")]
        [Authorize(Roles = "Digitador")]
        public IActionResult getDisciplinas() 
        {

            try 
            {

                return Ok(_CUListarDisciplinas.ListarDisciplinas());
            }
            catch (Exception e) 
            {
                return StatusCode(500);
            }
        }


        [HttpGet("ObtenerDisciplinaId/{id}")]
        [Authorize(Roles = "Digitador")]
        public IActionResult ObtenerDisciplina(int id)
        {

            try
            {
                DtoDisciplina dto = _CUObtenerDisciplinaId.ObtenerDisciplinaId(id);
                return Ok(dto);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }



        [HttpGet("ObtenerDisciplinaNombre/{nombre}")]
        [Authorize(Roles = "Digitador")]
        public IActionResult ObtenerDisciplinaNombre(string nombre)
        {

            try
            {
                DtoDisciplina dto  = _CUObtenerDisciplinaNombre.ObtenerDisciplinaNombre(nombre);
                return Ok(dto);//TODO
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }





        }
            private string EmailUser()
        {
            string email = null;
            // como obtener el email del token

            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                var emailClaim = claimsIdentity.Claims
                .FirstOrDefault(claim => claim.Type == ClaimTypes.Email);
                email = emailClaim.Value;
            }
            return email;
        }







    }
}
