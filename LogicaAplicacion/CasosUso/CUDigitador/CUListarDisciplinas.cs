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
    public class CUListarDisciplinas : ICUListarDisciplinas
    {
        IRepositorioDisciplina _repoDisciplina;

        public CUListarDisciplinas(IRepositorioDisciplina repositorioDisciplina)
        {
            _repoDisciplina = repositorioDisciplina;
        }
        public List<DtoDisciplina> ListarDisciplinas()
        {
            List<DtoDisciplina> dtoDisciplinas = MapperDisciplina.FromListDisciplinaToListDtoDisciplina(_repoDisciplina.FindAll());
            return dtoDisciplinas;
        }
    }
}
