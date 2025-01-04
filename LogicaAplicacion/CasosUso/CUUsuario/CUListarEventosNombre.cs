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
    public class CUListarEventosNombre:ICUListarEventosNombre
    {
        IRepositorioEvento _repoEventos;

        public CUListarEventosNombre(IRepositorioEvento repoEventos)
        {
            _repoEventos = repoEventos;
        }

        public List<DtoEvento> ListarEventosNombre(string nombre)
        {
            List<Evento> listaEventos = _repoEventos.FindEventoByNombreEvento(nombre);

            List<DtoEvento> DtolistaEventos = MapperEvento.FromListEventosToDtoListEvento(listaEventos);

            return DtolistaEventos;
        }
    }
}
