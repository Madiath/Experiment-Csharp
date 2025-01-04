using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Evento
    {
        public int Id { get; set; }
        public Disciplina Disciplina { get; set; }
        public string NombrePrueba { get; set; }
        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin {  get; set; }
        
        public List<EventoAtleta> listaAtletas { get; set; }

        public Evento() 
        {
        
        }

        public Evento(Disciplina disciplina, string nombrePrueba, DateTime fechaInicio, List<Atleta> listaAtletas, DateTime fechaFin)
        {
            Disciplina = disciplina;
            NombrePrueba = nombrePrueba;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
        }




    }
}
