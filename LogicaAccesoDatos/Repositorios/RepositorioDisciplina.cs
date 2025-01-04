using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioDisciplina : IRepositorioDisciplina
    {
        private ApplicationDbContext _context;

        public RepositorioDisciplina(ApplicationDbContext context)
        {
            _context = context;   
        }
        public void Add(Disciplina nuevo)
        {
            _context.Disciplinas.Add(nuevo);
            _context.SaveChanges();
        }

        public int AddWithInt(Disciplina nuevo)
        {
            _context.Disciplinas.Add(nuevo);
            _context.SaveChanges();
            return nuevo.Id;
        }


        public List<Disciplina> FindAll()
        {
           return _context.Disciplinas.OrderBy(a=> a.Nombre).ToList();

        }
          


        public Disciplina FindById(int id)
        {
            return _context.Disciplinas.Find(id);
        }

        public Disciplina FindByName(string name) 
        {
            return _context.Disciplinas.SingleOrDefault(a => a.Nombre == name);
        }

        public Disciplina FindByCode(string code) 
        {
            return _context.Disciplinas.SingleOrDefault(a => a.Codigo == code);
        }


        public void Remove(int id)
        {
            Disciplina? buscado = _context.Disciplinas.Where(d => d.Id == id).SingleOrDefault();
            if (buscado is null)
                throw new ArgumentNullException(nameof(buscado));

            _context.Remove(buscado);
            _context.SaveChanges();
        }

      


        public void Update(Disciplina obj)
        {
            _context.Disciplinas.Update(obj);
            _context.SaveChanges();
        }
    }
}
