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
    public class CUObtenerDisciplinaNombre : ICUObtenerDisciplinaNombre
    {
        IRepositorioDisciplina _repoDisciplina;
        public CUObtenerDisciplinaNombre(IRepositorioDisciplina repositorioDisciplina)
        {
            _repoDisciplina = repositorioDisciplina;
        }
        public DtoDisciplina ObtenerDisciplinaNombre(string nombre)
        {
            Disciplina disciplinaEncontrada = _repoDisciplina.FindByName(nombre);

            DtoDisciplina dto = MapperDisciplina.FromDisciplinaToDtoDisciplina(disciplinaEncontrada);
            return dto;
        }
    }
}
