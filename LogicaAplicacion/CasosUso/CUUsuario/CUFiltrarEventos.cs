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
    public class CUFiltrarEventos : ICUFiltrarEventos
    {

        private IRepositorioEvento _repoEvento;


        public CUFiltrarEventos(IRepositorioEvento repoEvento)
        {

            _repoEvento = repoEvento;


        }






        public IEnumerable<FiltrarEventoDTO> EjecutarListarEventos(int? disciplinaId, DateTime? fechaInicio, DateTime? fechaFin, string? nombreEvento, int? puntajeMin, int? puntajeMax)
        {
            List<Evento> listaEventos = _repoEvento.FiltroEvento(disciplinaId, fechaInicio, fechaFin, nombreEvento, puntajeMin, puntajeMax);

            List<FiltrarEventoDTO> DtolistaEventos = MapperEvento.FromDtoFiltrarEventos(listaEventos);

            return DtolistaEventos;
        }




    }
}
