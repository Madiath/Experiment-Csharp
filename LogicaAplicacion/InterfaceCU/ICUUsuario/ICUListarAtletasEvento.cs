using DTOs.EventoAtletaDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCU.ICUUsuario
{
    public interface ICUListarAtletasEvento
    {
        List<EventoAtletaDto> ListarAtletasEvento(int id);
    }
}
