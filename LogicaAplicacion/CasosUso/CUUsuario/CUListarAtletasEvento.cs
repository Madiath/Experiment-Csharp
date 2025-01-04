using DTOs.EventoAtletaDTOs;
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
    public class CUListarAtletasEvento : ICUListarAtletasEvento
    {

        IRepositorioEventoAtleta _repoEventoAtleta;

        public CUListarAtletasEvento(IRepositorioEventoAtleta repoEventoAtleta)
        {
            _repoEventoAtleta = repoEventoAtleta;
        }


        public List<EventoAtletaDto> ListarAtletasEvento(int id)
        {
            List<EventoAtleta> listaAtletas = _repoEventoAtleta.FindAllByEventoId(id);

            List<EventoAtletaDto> dto = MapperEventoAtleta.FromListEventoAtletaToDtoListEventoAtleta(listaAtletas);

            return dto;
        }
    }
}
