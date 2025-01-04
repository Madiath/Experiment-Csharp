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
    public class CUListarEventosEntreFechas:ICUListarEventosEntreFechas
    {
        IRepositorioEvento _repoEventos;

        public CUListarEventosEntreFechas(IRepositorioEvento repoEventos)
        {
            _repoEventos = repoEventos;
        }


        public List<DtoEvento> ListarEventosEntreFechas(DateTime fecha1, DateTime fecha2)
        {
            List<Evento> listaEventos = _repoEventos.FindEventoEntreFechas(fecha1, fecha2);

            List<DtoEvento> DtolistaEventos = MapperEvento.FromListEventosToDtoListEvento(listaEventos);

            return DtolistaEventos;
        }
    }
}
