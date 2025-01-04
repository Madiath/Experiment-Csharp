using DTOs.EventoAtletaDTOs;
using DTOs.EventoDTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfaceCU.ICUUsuario;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUObtenerEventosAtleta : ICUObtenerEventosAtleta
    {

        IRepositorioEventoAtleta _repoEventoAtleta;

        public CUObtenerEventosAtleta(IRepositorioEventoAtleta repoEventoAtleta)
        {
            _repoEventoAtleta   = repoEventoAtleta;
        }


        public List<DtoEvento> ObtenerEventosAtleta(int idAtleta)
        {
            List<EventoAtleta> lista = _repoEventoAtleta.FindAllByAtletaId(idAtleta);
            List<DtoEvento> retorno = MapperEvento.FromListEventoAtletaToListDtoEvento(lista);

            return retorno;
        }
    }
}
