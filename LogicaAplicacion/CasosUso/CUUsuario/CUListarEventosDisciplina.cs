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
    public class CUListarEventosDisciplina:ICUListarEventosDisciplina
    {
        IRepositorioEvento _repoEventos;

        public CUListarEventosDisciplina(IRepositorioEvento repoEventos)
        {
            _repoEventos = repoEventos;
        }
        public List<DtoEvento> ListarEventoByDisciplina(int id)
        {
            List<Evento> listaEventos = _repoEventos.FindEventoByDisciplina(id);

            List<DtoEvento> DtolistaEventos = MapperEvento.FromListEventosToDtoListEvento(listaEventos);

            return DtolistaEventos;
        }
    }
}
