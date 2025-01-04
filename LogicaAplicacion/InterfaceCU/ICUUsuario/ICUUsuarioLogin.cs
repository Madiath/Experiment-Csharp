using DTOs.UsuarioDTOs;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCU.ICUUsuario
{
    public interface ICUUsuarioLogin
    {
        DtoUsuarioLogin Login(DtoUsuarioLogin dto);

        DtoUsuarioLogin LoginCliente(DtoLogin dto);
    }
}
