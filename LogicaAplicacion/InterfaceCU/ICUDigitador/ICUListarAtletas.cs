using DTOs.AtletaDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCU.ICUDigitador
{
    public interface ICUListarAtletas
    {
        List<DtoListarAtletas> ListarAtletas();
    }
}
