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
    public class CUListarEventosPuntaje : ICUListarEventosPuntaje
    {
        IRepositorioEventoAtleta _repoEventoAlteta;
        public CUListarEventosPuntaje(IRepositorioEventoAtleta repositorioEventoAtleta)
        {
            _repoEventoAlteta = repositorioEventoAtleta;
        }
        public List<DtoEvento> ListarEventosPuntaje(int puntaje1, int puntaje2)
        {
            List<EventoAtleta> listaEventoAtleta = _repoEventoAlteta.FindEventosByPuntaje(puntaje1, puntaje2);
            List<DtoEvento> dto = MapperEvento.FromListEventoAtletaToListDtoEvento(listaEventoAtleta);
            return dto;
        }
    }
}
