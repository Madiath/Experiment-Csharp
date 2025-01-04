using DTOs.EventoAtletaDTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfaceCU.ICUUsuario;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUActualizarPuntuacion : ICUActualizarPuntuacion
    {
        IRepositorioEventoAtleta _repoEventoAtleta;
        IRepositorioAtleta _repoAtleta;
        IRepositorioEvento _repoEvento;
        public CUActualizarPuntuacion(IRepositorioEventoAtleta repoEventoAtleta, IRepositorioAtleta repoAtleta, IRepositorioEvento repoEvento)
        {
            _repoEventoAtleta = repoEventoAtleta;
            _repoAtleta = repoAtleta;
            _repoEvento = repoEvento;
        }



        public EventoAtletaDto ActualizarPuntuacion(int idAtleta, int idEvento)
        {
            Evento eventoEncontrado = _repoEvento.FindById(idEvento);
            Atleta atletaEncontrado = _repoAtleta.FindById(idAtleta);

            EventoAtletaDto dto = new EventoAtletaDto();
            dto.Atleta = atletaEncontrado;
            dto.Evento = eventoEncontrado;

            return dto;
        }

        public void PostActualizarPuntuacion(int idAtleta, int idEvento, int puntuacion)
        {
            EventoAtleta eventoAtleta = _repoEventoAtleta.FindByIdAtletaAndIdEvento(idAtleta,idEvento);
            eventoAtleta.Puntaje = puntuacion;
            _repoEventoAtleta.Update(eventoAtleta);


        }
    }
}
