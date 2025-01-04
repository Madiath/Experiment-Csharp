using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioUsuario :IRepositorioUsuario
    {
        private ApplicationDbContext _context;

        public RepositorioUsuario(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Usuario nuevo)
        {
            _context.Usuarios.Add(nuevo);
            _context.SaveChanges();
        }

        public List<Usuario> FindAll()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario FindById(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public void Remove(int id)
        {
            Usuario usuarioEncontrado = FindById(id);
           _context.Usuarios.Remove(usuarioEncontrado);
            _context.SaveChanges();
        }

        public void Update(Usuario obj)
        {
            _context.Usuarios.Update(obj);
            _context.SaveChanges();
        }


        public Usuario FindByGmail(string email) 
        {
         Usuario buscado = _context.Usuarios.Where(u=> u.Email == email).SingleOrDefault();
            return buscado;
        }
    }
}
