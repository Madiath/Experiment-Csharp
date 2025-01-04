using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioEventoAtleta : IRepositorio<EventoAtleta>
    {
        public List<EventoAtleta> FindAllByEventoId(int id);

        public EventoAtleta FindByIdAtletaAndIdEvento(int idAtleta, int idEvento);

        public List<EventoAtleta> FindAllByAtletaId(int idAtleta);

        public List<EventoAtleta> FindEventosByPuntaje(int puntaje1, int puntaje2);

    }
}
