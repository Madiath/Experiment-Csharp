using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Atleta
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Sexo { get; set; }

        
        public Pais Pais {  get; set; }
     
        public string DelegadoTelefono {  get; set; }
        public string DelegadoNombre { get; set; }
       public  List<Disciplina> _listaDisiplinas {  get; set; }

        public Atleta() 
        {
        
        }
        public Atleta(string nombreCompleto, string sexo, Pais pais, int cantidad, string delegadoTelefono, string delegadoNombre, List<Disciplina> listaDisciplinas)
        {
            NombreCompleto = nombreCompleto;
            Sexo = sexo;
            Pais = pais;
           
            DelegadoTelefono = delegadoTelefono;
            DelegadoNombre = delegadoNombre;
            _listaDisiplinas = listaDisciplinas;
        }
    }
}
