using DTOs.DisciplinaDTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfaceCU.ICUDigitador;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUDigitador
{
    public class CUObtenerDisciplinaId : ICUObtenerDisciplinaId
    {
        IRepositorioDisciplina _repoDisciplina;
        public CUObtenerDisciplinaId(IRepositorioDisciplina repoDisciplina)
        {
            _repoDisciplina = repoDisciplina;
        }
        public DtoDisciplina ObtenerDisciplinaId(int id)
        {
            Disciplina disciplinaEncontrada = _repoDisciplina.FindById(id);

            DtoDisciplina dto = MapperDisciplina.FromDisciplinaToDtoDisciplina(disciplinaEncontrada);
            return dto;
        }
    }
}
