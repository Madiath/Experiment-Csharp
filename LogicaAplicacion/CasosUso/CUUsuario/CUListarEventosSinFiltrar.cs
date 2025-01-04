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
    public class CUListarEventosSinFiltrar : ICUListarEventosSinFiltrar
    {
        IRepositorioEvento _repoEvento;



        public CUListarEventosSinFiltrar(IRepositorioEvento repoEvento)
        {
            _repoEvento = repoEvento;
        }



        public List<DtoEvento> ListarEventosSinFiltracion()
        {
            List<Evento> listaEventos = _repoEvento.FindAll();

            List<DtoEvento> dtoEventos = MapperEvento.FromListEventosToDtoListEvento(listaEventos);

            return dtoEventos;

        }
    }
}
