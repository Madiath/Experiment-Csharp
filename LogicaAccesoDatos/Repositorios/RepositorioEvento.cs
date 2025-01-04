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
    public class RepositorioEvento : IRepositorioEvento
    {
        private ApplicationDbContext _context;

        public RepositorioEvento(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Evento nuevo)
        {
            _context.Eventos.Add(nuevo);
            _context.SaveChanges();
        }

       
            public List<Evento> FiltroEvento(
       int? disciplinaId,
       DateTime? fechaInicio,
       DateTime? fechaFin,
       string? nombreEvento,
       int? puntajeMin,
       int? puntajeMax)
            {
                try
                {
                    var query = _context.Eventos
                        .Include(e => e.Disciplina)
                        .Include(e => e.listaAtletas)
                        .AsEnumerable();

                    // Filtro por disciplina
                    if (disciplinaId != null)
                    {
                        query = query.Where(e => e.Disciplina.Id == disciplinaId).AsEnumerable();
                    }

                    // Filtro por fechas
                    if (fechaInicio != null && fechaFin != null)
                    {
                        var inicio = fechaInicio.Value.Date;
                        var fin = fechaFin.Value.Date.AddDays(1).AddTicks(-1);
                        query = query.Where(e => e.FechaInicio >= inicio && e.FechaFin <= fin);
                    }

                    // Filtro por nombre del evento
                    if (!string.IsNullOrWhiteSpace(nombreEvento))
                    {
                        query = query.Where(e => e.NombrePrueba.ToLower().Contains(nombreEvento.ToLower()));
                    }

                    // Filtro por rango de puntajes
                    if (puntajeMin != null && puntajeMax != null)
                    {
                        query = query.Where(e => e.listaAtletas.Any(ap =>
                            ap.Puntaje >= puntajeMin && ap.Puntaje <= puntajeMax));
                    }

                    return query.ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("No se encontraron eventos para el filtro deseado", ex);
                }
            }
        

        public List<Evento> FindAll()
        {
            return _context.Eventos.ToList();
        }
    

        public List<Evento> FindAllByDate(DateTime fecha)
        {
            return _context.Eventos.Where(a=> a.FechaInicio == fecha).ToList();
        }



        public Evento FindById(int id)
        {
            return _context.Eventos.Find(id);
        }


        public Evento FindByName(string nombre) 
        {
            return _context.Eventos.SingleOrDefault(e => e.NombrePrueba == nombre);
        }

        public List<Evento> FindEventoByDisciplina(int id)
        {
            return _context.Eventos.Include(e => e.Disciplina).Where(e => e.Disciplina.Id == id).ToList();
        }

        //Listado de Eventos Por el Nombre

        public List<Evento> FindEventoByNombreEvento(string nombre)
        {
            return _context.Eventos.Where(e => e.NombrePrueba == nombre).ToList();
        }

        // Listado Entre Fechas 
        public List<Evento> FindEventoEntreFechas(DateTime fecha1, DateTime fecha2)
        {
            return _context.Eventos.Where(a => a.FechaInicio >= fecha1 && a.FechaFin <= fecha2).ToList();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Evento obj)
        {
            _context.Eventos.Update(obj);
            _context.SaveChanges();
        }
    }
}
