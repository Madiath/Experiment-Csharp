using DTOs.DisciplinaDTOs;
using DTOs.EventoDTOs;
using LogicaAplicacion.InterfaceCU.ICUDigitador;
using LogicaNegocio.Exepciones.ExepcionesDigitador;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace webApp.Controllers
{
    public class DigitadorController : Controller
    {
        ICUListarAtletas _CUListarAtletas;
        ICUAgregarDisciplina _CUAgregarDisciplina;
        ICUAltaDisciplina _CUAltaDisciplina;
        ICUListarDisciplinas _CUListarDisciplinas;
        
        public DigitadorController(ICUListarAtletas cuListarAtletas, ICUAgregarDisciplina cUAgregarDisciplina,ICUAltaDisciplina cUAltaDisciplina, 
            ICUListarDisciplinas cUListarDisciplinas)
        {
            _CUListarAtletas = cuListarAtletas;
            _CUAgregarDisciplina = cUAgregarDisciplina;
            _CUAltaDisciplina = cUAltaDisciplina;
            _CUListarDisciplinas = cUListarDisciplinas;
            
        }

        public ActionResult Index()
        {
            return View();
        }

        //Metodo para listar atletas
        public ActionResult ListarAtletas()
        {
            return View(_CUListarAtletas.ListarAtletas());
        }


        //Metodo para listar disciplina
        public ActionResult ListarDisciplina() 
        {
            return View(_CUListarDisciplinas.ListarDisciplinas());
        }


        //Metodo para realizar un alta de disciplina
        public ActionResult AltaDisciplina() 
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult AltaDisciplina(DtoDisciplina dto)
        {
            try
            {
                dto.AnioDisciplina = DateTime.Now;
                _CUAltaDisciplina.AltaDisciplina(dto);
                ViewBag.msg = "Disciplina creada con exito!";
                return View();
            }
            catch (AgregarDisciplinaNombreYaExisteException e)
            {
                ViewBag.msg = e.Message;
                return View();
            }
            catch (AgregarDisciplinaCodigoYaExisteException e) 
            {
                ViewBag.msg = e.Message;
                return View();
            }
            
        }


        //Metodo para agregar una disciplina al atleta
        public ActionResult AgregarDisciplina(int id) 
        {
            return View(_CUAgregarDisciplina.AgregarDisciplina(id));
        }
        [HttpPost]
        public ActionResult AgregarDisciplina(int idAtleta, List<int> IdsDisciplinas)
        {

            try
            {
                _CUAgregarDisciplina.PostAgregarDisciplina(idAtleta, IdsDisciplinas);
                ViewBag.msg = "Disciplina agregada con exito!";
                return View(_CUAgregarDisciplina.AgregarDisciplina(idAtleta));
            }
            catch (AsociarDisYaTieneEsaDisciplinaAtletaException e)
            {
              ViewBag.msg ="La disciplina "+ e.Message +" ,ya esta asociada al atleta";
              return View(_CUAgregarDisciplina.AgregarDisciplina(idAtleta));
            }
        }










        public ActionResult Create()
        {
            return View();
        }

       
        public ActionResult Create(IFormCollection collection)
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

        // GET: DigitadorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DigitadorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: DigitadorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DigitadorController/Delete/5
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
