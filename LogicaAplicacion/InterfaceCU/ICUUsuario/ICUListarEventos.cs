﻿using DTOs.EventoDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCU.ICUUsuario
{
    public interface ICUListarEventos
    {
        List<DtoEvento> ListarEvento(DateTime fecheDeEvento);
    }
}
