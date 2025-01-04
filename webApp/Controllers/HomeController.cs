using DTOs.EventoDTOs;
using DTOs.UsuarioDTOs;
using LogicaAplicacion.CasosUso.CUUsuario;
using LogicaAplicacion.InterfaceCU.ICUUsuario;
using LogicaNegocio.Exepciones.ExepcionesUsuario;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Diagnostics;
using webApp.Models;

namespace webApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ICUUsuarioLogin _CULOGIN;
        ICUAltaEvento _CUAltaEvento;
        ICUListarEventos _CUListarEventos;
        ICUListarAtletasEvento _CUListarAtletasEvento;
        ICUActualizarPuntuacion _CUActualizarPuntuacion;
        ICUListarEventosSinFiltrar _CUListarEventosSinFiltrar;

        public HomeController(ILogger<HomeController> logger, ICUUsuarioLogin login, ICUAltaEvento cUALTAEvento, ICUListarEventos cUListarEventos, ICUListarAtletasEvento cUListarAtletasEvento, ICUActualizarPuntuacion cUActualizarPuntuacion, ICUListarEventosSinFiltrar cUListarEventosSinFiltrar)
        {
            _CULOGIN = login;
            _logger = logger;
            _CUAltaEvento = cUALTAEvento;
            _CUListarEventos = cUListarEventos;
            _CUListarAtletasEvento = cUListarAtletasEvento;
            _CUActualizarPuntuacion = cUActualizarPuntuacion;
            _CUListarEventosSinFiltrar = cUListarEventosSinFiltrar;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        //Metodo para logearse
        public IActionResult Login() 
        {
            return View(); 
        }
        [HttpPost]
        public IActionResult Login(DtoUsuarioLogin dto)
        {

            try
            {
                DtoUsuarioLogin dtoLogin = _CULOGIN.Login(dto);

                if (dtoLogin.Rol.Equals("Administrador"))
                {
                    HttpContext.Session.SetString("rol", "Administrador");
                    HttpContext.Session.SetString("gmail", dtoLogin.Email);
                    HttpContext.Session.SetInt32("id", dto.IdUsuario);
                    return RedirectToAction("Index", "Home");
                }
                else if (dtoLogin.Rol.Equals("Digitador"))
                {
                    HttpContext.Session.SetString("rol", "Digitador");
                    HttpContext.Session.SetString("gmail", dtoLogin.Email);
                    return RedirectToAction("Index", "Home");
                }


                return View();
            }
            catch (EmailNoEncontradoException email)
            {
                ViewBag.msg = email.Message;
                return View();
            }
            catch (ContraseniaIncorrectaException contra)
            {
                ViewBag.msg = contra.Message;
                return View();
            }
            catch (Exception ex) 
            {
                ViewBag.msg = "Un error a ocurrido al iniciar la request";
                return View();
            }
            
        }


        //Metodo para cerrar sesion
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }







        //Metodo para el Alta evento
        public IActionResult AltaEvento()
        {
            return View(_CUAltaEvento.AltaEvento());
        }


        [HttpPost]
        public IActionResult AltaEvento(DtoAltaEvento dto)
        {

            try
            {
                _CUAltaEvento.PostAltaEvento(dto);
                ViewBag.msg = "Evento agregado con exito!";
                return View(_CUAltaEvento.AltaEvento());
            }
            catch (AltaEventoNombreYaExisteException e)
            {
                ViewBag.msg = e.Message;
                return View(_CUAltaEvento.AltaEvento());
            }
            catch (AltaEventoTresAtletasException e) 
            {
                ViewBag.msg = e.Message;
                return View(_CUAltaEvento.AltaEvento());
            }
            catch (AltaEventoAtletasDisciplinaException e) 
            {
                ViewBag.msg ="El atleta "+e.Message+", no contiene la disciplina seleccionada";
                return View(_CUAltaEvento.AltaEvento());
            }
            
        }






        //Metodo para llamar a listar eventos con la fecha
        public IActionResult FiltrarEventos()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FiltrarEventos(DateTime fechainicio) 
        {
         return RedirectToAction("ListarEventos","Home", new { laFecha = fechainicio });
        }
        public IActionResult ListarEventos(DateTime laFecha) 
        {
         return View(_CUListarEventos.ListarEvento(laFecha));
        }

        //Metodo para listar los eventos sin filtrar
        public IActionResult ListarEventosSinFiltrar() 
        {
            return View(_CUListarEventosSinFiltrar.ListarEventosSinFiltracion());
        }








        //Metodo para listar atletas segun el Evento

        public IActionResult ListarAtletasEvento(int id) 
        {
            return View(_CUListarAtletasEvento.ListarAtletasEvento(id));
        }




        //Metodo para agregar puntuacion
        public IActionResult ActualizarPuntuacion(int idAtleta, int idEvento) 
        {
           return View(_CUActualizarPuntuacion.ActualizarPuntuacion(idAtleta,idEvento));
        }

        [HttpPost]
        public IActionResult ActualizarPuntuacion(int idAtleta, int idEvento,int puntaje)
        {
            _CUActualizarPuntuacion.PostActualizarPuntuacion(idAtleta, idEvento, puntaje);
            ViewBag.msg = "Puntuacion agregado con exito";
            return View(_CUActualizarPuntuacion.ActualizarPuntuacion(idAtleta, idEvento));
        }


    }
}
