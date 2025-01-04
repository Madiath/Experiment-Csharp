using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioEventoAtleta : IRepositorioEventoAtleta
    {
        private ApplicationDbContext _context;

        public RepositorioEventoAtleta(ApplicationDbContext context)
        {
            _context = context;
        }


        public void Add(EventoAtleta nuevo)
        {
            _context.EventosAtletas.Add(nuevo);
            _context.SaveChanges();
        }

        public List<EventoAtleta> FindAll()
        {
            return _context.EventosAtletas.ToList();
        }


        public List<EventoAtleta> FindAllByEventoId(int id)
        {
            return _context.EventosAtletas.Include(b => b.Atleta).Include(c => c.Evento).Where(a => a.EventoId == id).ToList();
        }


        public List<EventoAtleta> FindAllByAtletaId(int idAtleta) 
        {
            return _context.EventosAtletas.Include(e => e.Evento).ThenInclude(ev => ev.Disciplina).Where(a => a.AtletaId == idAtleta) .OrderBy(e => e.Evento.Disciplina.Nombre).ToList();
        }



        public EventoAtleta FindById(int id)
        {
            return _context.EventosAtletas.Find(id);
        }

        public EventoAtleta FindByIdAtletaAndIdEvento(int idAtleta, int idEvento) 
        {
            return _context.EventosAtletas.SingleOrDefault(a=> a.AtletaId == idAtleta && a.EventoId == idEvento);
        }


        public void Remove(int id)
        {
            _context.EventosAtletas.Remove(FindById(id));
            _context.SaveChanges();
        }

        public void Update(EventoAtleta obj)
        {
            _context.EventosAtletas.Update(obj);
            _context.SaveChanges();
        }

        public List<EventoAtleta> FindEventosByPuntaje(int puntaje1, int puntaje2)
        {
            List<EventoAtleta> lista = _context.EventosAtletas.Include(e => e.Evento).ThenInclude(e=> e.Disciplina).Where(e => e.Puntaje >= puntaje1 && e.Puntaje <= puntaje2).ToList(); 
                return lista;
        }
    }
}
