using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.EventoAtletaDTOs
{
    public class EventoAtletaDto
    {
        public int Id {  get; set; }

        public int Puntaje {  get; set; }
        public Evento Evento { get; set; }
        public Atleta Atleta { get; set; }
    }
}
