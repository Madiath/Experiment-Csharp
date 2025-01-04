using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioDisciplina: IRepositorio<Disciplina>
    {
        public Disciplina FindByName(string name);
        public Disciplina FindByCode(string code);
        public int AddWithInt(Disciplina nuevo);
    
    }
}
