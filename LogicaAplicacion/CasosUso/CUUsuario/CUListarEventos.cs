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
    public class CUListarEventos: ICUListarEventos
    {
        IRepositorioEvento _repoEventos;

        public CUListarEventos(IRepositorioEvento repoEventos)
        {
            _repoEventos = repoEventos;
        }




        public List<DtoEvento> ListarEvento(DateTime fecheDeEvento)
        {
            List<Evento> listaEventos = _repoEventos.FindAllByDate(fecheDeEvento);

            List<DtoEvento> DtolistaEventos = MapperEvento.FromListEventosToDtoListEvento(listaEventos);

            return DtolistaEventos;
        }
    }
}
