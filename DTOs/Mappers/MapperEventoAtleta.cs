using DTOs.EventoAtletaDTOs;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Mappers
{
    public class MapperEventoAtleta
    {

        public static List<EventoAtletaDto> FromListEventoAtletaToDtoListEventoAtleta(List<EventoAtleta> listaEventoAtleta) 
        {
          List<EventoAtletaDto> dto = new List<EventoAtletaDto>();


            foreach(EventoAtleta evtAtl in listaEventoAtleta) 
            {
              EventoAtletaDto unDato = new EventoAtletaDto();
                unDato.Atleta = evtAtl.Atleta;
                unDato.Puntaje = evtAtl.Puntaje;
                unDato.Evento = evtAtl.Evento;
                dto.Add(unDato);
            }
            return dto;
        }

        public static EventoAtleta FromEventoAtletaDtoToEventoAtleta(EventoAtletaDto dto) 
        {
          EventoAtleta eventoAtleta = new EventoAtleta();
            eventoAtleta.Atleta = dto.Atleta;
            eventoAtleta.Evento = dto.Evento;
            eventoAtleta.Puntaje = dto.Puntaje;
            return eventoAtleta;
        }


    }
}
