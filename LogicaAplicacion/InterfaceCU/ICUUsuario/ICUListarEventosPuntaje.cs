using DTOs.EventoDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCU.ICUUsuario
{
    public interface ICUListarEventosPuntaje
    {
        List<DtoEvento> ListarEventosPuntaje(int puntaje1, int puntaje2);
    }
}
