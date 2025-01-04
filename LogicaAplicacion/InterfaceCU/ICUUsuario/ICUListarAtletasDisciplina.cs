using DTOs.AtletaDTOs;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCU.ICUUsuario
{
    public interface ICUListarAtletasDisciplina
    {
        List<DtoListarAtletas> ListarAtletasDisciplina(int id); 
    }
}
