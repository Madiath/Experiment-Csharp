using DTOs.UsuarioDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCU
{
    public interface ICUAltaUsuario
    {
        void AltaUsuario(DtoAltaUsuario dto);
    }
}
