using DTOs.UsuarioDTOs;
using LogicaAplicacion.InterfaceCU;
using LogicaAplicacion.InterfaceCU.ICUUsuario;
using LogicaNegocio.Entidades;
using LogicaNegocio.Exepciones.ExepcionesAdministrador;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace webApp.Controllers
{
    public class AdministradorController : Controller
    {

        ICUAltaUsuario _AltaUsuario;
        ICUListarUsuarios _ListarUsuarios;
        IRepositorioUsuario _repoUsuarios;
       

        public AdministradorController(ICUAltaUsuario altaUsuario, ICUListarUsuarios listarUsuarios, IRepositorioUsuario repoUsuarios)
        {
            _AltaUsuario = altaUsuario;
            _ListarUsuarios = listarUsuarios;
            _repoUsuarios = repoUsuarios;
            
        }



        public ActionResult Index()
        {
            return View();
        }

        // GET: AdministradorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //Metodo para dar alta a un USUARIO
        public ActionResult AltaUsuario()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AltaUsuario(DtoAltaUsuario dto)
        {
            try
            {
                int? idAdministrador = HttpContext.Session.GetInt32("id");

                DateTime fechaDeAhora = DateTime.Now;
                dto.IdAdmin = idAdministrador;
                dto.FechaIngreso = fechaDeAhora;
                _AltaUsuario.AltaUsuario(dto);
                ViewBag.msg = "Se a añadido el usuario correctamente";
                return View();
            }
            catch (AltaUsuarioExisteException e)
            {
                ViewBag.msg = e.Message;
                return View();
            }
            catch (AltaRolNoValidoException e) 
            {
                ViewBag.msg = e.Message;
                return View();
            }
            
        }


        //Metodo para ver la lista de usuarios
        public ActionResult ListarUsuarios()
        {
            return View(_ListarUsuarios.ListarUsuarios());
        }




        //Metodo dar de baja a un usuario

        public ActionResult BajaUsuario(int id) 
        {
          _repoUsuarios.Remove(id);
            return RedirectToAction("ListarUsuarios", "Administrador");
        }



        //Metodo para editar a un usuario
        public ActionResult EditarUsuario(int id) 
        {
           Usuario usuarioBuscado = _repoUsuarios.FindById(id);
            return View(usuarioBuscado);
        }

        [HttpPost]
        public ActionResult EditarUsuario(Usuario usuarioBuscado) 
        {
            _repoUsuarios.Update(usuarioBuscado);
            ViewBag.msg = "Usuario modificado con exito";
            return View();
        }
















        // GET: AdministradorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdministradorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
