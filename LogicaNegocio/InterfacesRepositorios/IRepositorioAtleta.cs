using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioAtleta:IRepositorio<Atleta>
    {
        public Atleta FindByIdWithDisciplinas(int id);
        public List<Atleta> FindAllWithDisciplinas();

        public List<Atleta> AllAtletasDisciplina(Disciplina disciplina);
    }
}
