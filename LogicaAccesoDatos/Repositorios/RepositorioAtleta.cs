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
    public class RepositorioAtleta : IRepositorioAtleta
    {
        private ApplicationDbContext _context;

        public RepositorioAtleta(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Atleta nuevo)
        {
            _context.Atletas.Add(nuevo);
            _context.SaveChanges();
        }

        public List<Atleta> AllAtletasDisciplina(Disciplina disciplina)
        {
            return _context.Atletas.Include(d=> d.Pais).Include(d => d._listaDisiplinas).Where(d => d._listaDisiplinas.Contains(disciplina)).OrderBy(d=>d.NombreCompleto).ToList();
        }

        public List<Atleta> FindAll()
        {
            return _context.Atletas.Include(a => a.Pais).OrderBy(a => a.NombreCompleto).ThenBy(a => a.Pais.Nombre).ToList();
        }
        public List<Atleta> FindAllWithDisciplinas()
        {
            return _context.Atletas.Include(a => a._listaDisiplinas).ToList();
        }




        public Atleta FindById(int id)
        {
            return _context.Atletas.Find(id);
        }

        public Atleta FindByIdWithDisciplinas(int id)
        {
            return _context.Atletas.Include(a=> a._listaDisiplinas).FirstOrDefault(e=> e.Id == id);
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Atleta obj)
        {
            _context.Atletas.Update(obj);
            _context.SaveChanges();
        }
    }
}
