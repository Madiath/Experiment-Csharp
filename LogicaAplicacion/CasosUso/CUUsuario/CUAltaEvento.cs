using DTOs.AtletaDTOs;
using DTOs.DisciplinaDTOs;
using DTOs.EventoDTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfaceCU.ICUUsuario;
using LogicaNegocio.Entidades;
using LogicaNegocio.Exepciones.ExepcionesUsuario;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUAltaEvento : ICUAltaEvento
    {
        IRepositorioEvento _repoEvento;
        IRepositorioDisciplina _repoDisciplina;
        IRepositorioAtleta _repoAtleta;
        IRepositorioEventoAtleta _repoEventoAtleta;

        public CUAltaEvento(IRepositorioEvento repoEvento, IRepositorioAtleta repoAtleta, IRepositorioEventoAtleta repoEventoAtleta, IRepositorioDisciplina repoDisciplina)
        {
            _repoEvento = repoEvento;
            _repoAtleta = repoAtleta;
            _repoEventoAtleta = repoEventoAtleta;
            _repoDisciplina = repoDisciplina;
        }

        public DtoAltaEvento AltaEvento()
        {
            List<Atleta> atletas = _repoAtleta.FindAll();
            List<Disciplina> disciplinas = _repoDisciplina.FindAll();

            List<DtoListarAtletas> dtoAtletas = MapperAtleta.FromListAtletaToListDtoListarAtletas(atletas);
            List<DtoDisciplina> dtoDisciplinas = MapperDisciplina.FromListDisciplinaToListDtoDisciplina(disciplinas);

            DtoAltaEvento altaEvento = new DtoAltaEvento();
            altaEvento.Atletas = dtoAtletas;
            altaEvento.Disciplinas = dtoDisciplinas;
            return altaEvento;
        }

        public void PostAltaEvento(DtoAltaEvento dto)
        {
            Evento eventoEncontradoNombre = _repoEvento.FindByName(dto.Nombre);
            if (eventoEncontradoNombre != null)
            {
                throw new AltaEventoNombreYaExisteException("Ya hay un evento con ese nombre");
            }



            List<Atleta> listaAtletas = new List<Atleta>();

            //Busco a los atletas seleccionados
            foreach (Atleta a in _repoAtleta.FindAllWithDisciplinas())
            {
                foreach (int id in dto.AtletasID)
                {
                    if (a.Id == id)
                    {
                        listaAtletas.Add(a);
                    }
                }
            }


            if (listaAtletas.Count() < 3)
            {
                throw new AltaEventoTresAtletasException("Tiene que haber almenos 3 atletas seleccionados");
            }


            //Busco la disciplina seleccionada
            Disciplina disciplina = _repoDisciplina.FindById(dto.DisciplinaID);

            foreach (Atleta atleta in listaAtletas)
            {
                if (!atleta._listaDisiplinas.Contains(disciplina))
                {
                    throw new AltaEventoAtletasDisciplinaException(atleta.NombreCompleto);
                }
            }



          


            //Hago el alta
            Evento nuevoEvento = MapperEvento.FromDtoAltaEventoToEvento(dto);
            nuevoEvento.Disciplina = disciplina;
            

            _repoEvento.Add(nuevoEvento);
            
            



        }
    }
}
