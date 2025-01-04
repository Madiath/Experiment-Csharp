using DTOs.AtletaDTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfaceCU.ICUUsuario;
using LogicaNegocio.Entidades;
using LogicaNegocio.Exepciones.ExepcionesDisciplina;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUListarAtletasDisciplina : ICUListarAtletasDisciplina
    {
        IRepositorioAtleta _RepositorioAtleta;
        IRepositorioDisciplina _RepositorioDisciplina;

        public CUListarAtletasDisciplina(IRepositorioAtleta repoAtletas, IRepositorioDisciplina repoDisciplina)
        {
            _RepositorioAtleta = repoAtletas;
            _RepositorioDisciplina = repoDisciplina;
        }
        public List<DtoListarAtletas> ListarAtletasDisciplina(int id)
        {
            Disciplina disciplina = _RepositorioDisciplina.FindById(id);
            if (disciplina == null) 
            {
              throw new DisciplinaNoEncontradaException(); 
            }
            List<Atleta> atletas = _RepositorioAtleta.AllAtletasDisciplina(disciplina);
            if (atletas==null) 
            {
               throw new NoAtletasDisciplinaException();
            }

            List<DtoListarAtletas> dtoAtletas = MapperAtleta.FromListAtletaToListDtoListarAtletas(atletas);

            return dtoAtletas;
        }
    }
}
