using DTOs.EventoAtletaDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCU.ICUUsuario
{
    public interface ICUActualizarPuntuacion
    {
        EventoAtletaDto ActualizarPuntuacion(int idAtleta, int idEvento);

        void PostActualizarPuntuacion(int idAtleta, int idEvento, int puntuacion);
    }
}
