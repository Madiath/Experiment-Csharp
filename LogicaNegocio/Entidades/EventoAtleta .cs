using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class EventoAtleta
    {
        public int Id { get; set; }
        public int Puntaje { get; set; }

        
        public int EventoId { get; set; }
      
        public int AtletaId { get; set; }

        public Evento Evento { get; set; }
        public Atleta Atleta { get; set; }


        public EventoAtleta()
        {
            
        }


        public EventoAtleta(Evento evento , Atleta atleta, int puntaje)
        {
            Evento = evento;
            Atleta = atleta;
            Puntaje = puntaje;
        }
    }
}
