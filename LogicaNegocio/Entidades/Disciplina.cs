using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Disciplina
    {
        public string Nombre { get; set; }
       
        public string Codigo { get; set; }
        public int Id { get; set; }

        public DateTime? AnioDisciplina {  get; set; }
        
        public List<Atleta> ListaAtletas { get; set; }


        public Disciplina() 
        {
        
        }
        public Disciplina(string nombre, DateTime anioDisciplina)
        {
            Nombre = nombre;
            AnioDisciplina = anioDisciplina;
        }
    }
}
