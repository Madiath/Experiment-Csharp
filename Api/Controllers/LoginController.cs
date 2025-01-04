using DTOs.UsuarioDTOs;
using LogicaAplicacion.InterfaceCU.ICUUsuario;
using LogicaNegocio.Exepciones.ExepcionesUsuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Console;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ICUUsuarioLogin _CUUsuarioLogin;

        public LoginController(ICUUsuarioLogin cuLogin)
        {
            _CUUsuarioLogin = cuLogin;
        }



        [HttpPost("login")]
        public IActionResult Login([FromBody] DtoLogin login)
        {

            try
            {

                DtoUsuarioLogin dtoLogin = _CUUsuarioLogin.LoginCliente(login);

                // Validación básica de credenciales

                // Crear el token JWT

                var claveDificil = "UTzl^7yPl$5xrT6&{7RZCSG&O42MEK-89$CW1XXRrN(>XqIp{W4s2S5$>KT$6CG!2M]'ZlrqH-t%eI4.X9W~u#qO+oX£+[?7QDAa";
                var claveDificilEncriptada = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(claveDificil));
                List<Claim> claims = [
                    new Claim(ClaimTypes.Email, dtoLogin.Email),
                    new Claim(ClaimTypes.Role, dtoLogin.Rol)
                ];

                var credenciales = new SigningCredentials(claveDificilEncriptada, SecurityAlgorithms.HmacSha512Signature);

                var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: credenciales);

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);


                return Ok(new { Token = jwt });

            }
            catch (Exception ex) 
            {
                return Unauthorized();
            }


        }


    }
}
