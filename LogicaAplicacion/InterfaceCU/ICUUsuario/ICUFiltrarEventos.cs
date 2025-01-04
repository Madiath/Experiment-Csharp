using DTOs.EventoDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCU.ICUUsuario
{
    public interface ICUFiltrarEventos
    {
        public IEnumerable<FiltrarEventoDTO> EjecutarListarEventos(int? disciplinaId, DateTime? fechaInicio, DateTime? fechaFin, string? nombreEvento, int? puntajeMin, int? puntajeMax);
    }
}
