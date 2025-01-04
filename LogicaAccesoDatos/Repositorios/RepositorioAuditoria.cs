using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioAuditoria : IRepositorioAuditoria
    {
        private ApplicationDbContext _context;

        public RepositorioAuditoria(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Auditoria nuevo)
        {
            _context.Auditoria.Add(nuevo);
            _context.SaveChanges();
        }

        public List<Auditoria> FindAll()
        {
            throw new NotImplementedException();
        }

        public Auditoria FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Auditoria obj)
        {
            throw new NotImplementedException();
        }
    }
}
