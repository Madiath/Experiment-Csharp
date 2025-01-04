using DTOs.EventoDTOs;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Mappers
{
    public class MapperEvento
    {

        public static Evento FromDtoAltaEventoToEvento(DtoAltaEvento dto) 
        {
            Evento evento = new Evento();
            evento.NombrePrueba = dto.Nombre;
           
       

            evento.listaAtletas = dto.AtletasID.Select(a=> new EventoAtleta {AtletaId = a }).ToList();

            evento.FechaInicio = dto.FechaInicio;
            evento.FechaFin = dto.FechaFin;

            return evento;
        }


        public static List<DtoEvento> FromListEventosToDtoListEvento(List<Evento> eventos)
        {
            List<DtoEvento> listaEventos = new List<DtoEvento>();

            foreach (Evento evento in eventos)
            {
                DtoEvento dtoEvento = new DtoEvento();
                dtoEvento.Id = evento.Id;
                dtoEvento.Nombre = evento.NombrePrueba;
                dtoEvento.Disciplina = evento.Disciplina;
                dtoEvento.FechaInicio = evento.FechaInicio;
                dtoEvento.FechaFin = evento.FechaFin;
                listaEventos.Add(dtoEvento);
            }
            return listaEventos;
        }



        public static List<DtoEvento> FromListEventoAtletaToListDtoEvento(List<EventoAtleta>EventosAtl)
        {
            List<DtoEvento> listaEventos = new List<DtoEvento>();

            foreach (EventoAtleta eventoatl in EventosAtl)
            {
                DtoEvento dtoEvento = new DtoEvento();
                dtoEvento.Id = eventoatl.Evento.Id;
                dtoEvento.Nombre = eventoatl.Evento.NombrePrueba;
                dtoEvento.Disciplina = eventoatl.Evento.Disciplina;
                dtoEvento.FechaInicio = eventoatl.Evento.FechaInicio;
                dtoEvento.FechaFin = eventoatl.Evento.FechaFin;
                listaEventos.Add(dtoEvento);
            }
            return listaEventos;
        }



        public static List<FiltrarEventoDTO> FromDtoFiltrarEventos(List<Evento> listaEventos)
        {
            List<FiltrarEventoDTO> listaFiltrarEventosDto = new List<FiltrarEventoDTO>();

            foreach (var evento in listaEventos)
            {
                // Inicializamos los valores del rango de puntajes a 0 si no hay atletas participantes
                int rangoPuntaje1 = 0;
                int rangoPuntaje2 = 0;

                if (evento.listaAtletas != null && evento.listaAtletas.Any())
                {
                    rangoPuntaje1 = evento.listaAtletas.Min(p => p.Puntaje);
                    rangoPuntaje2 = evento.listaAtletas.Max(p => p.Puntaje);
                }

                FiltrarEventoDTO dto = new FiltrarEventoDTO
                {
                    IdDisciplina = evento.Disciplina.Id,
                    NombreDePrueba = evento.NombrePrueba,
                    FechaDeInicio = evento.FechaInicio,
                    FechaDeFin = evento.FechaFin,
                    RangoPuntaje1 = rangoPuntaje1,
                    RangoPuntaje2 = rangoPuntaje2
                };

                listaFiltrarEventosDto.Add(dto);
            }

            return listaFiltrarEventosDto;
        }



    }
}
