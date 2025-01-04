using DTOs.DisciplinaDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCU.ICUDigitador
{
    public interface ICUObtenerDisciplinaId
    {
        DtoDisciplina ObtenerDisciplinaId(int id);
    }
}
