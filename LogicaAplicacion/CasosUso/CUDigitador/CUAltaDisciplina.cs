using DTOs.DisciplinaDTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfaceCU.ICUDigitador;
using LogicaNegocio.Entidades;
using LogicaNegocio.Exepciones.ExepcionesDigitador;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUDigitador
{
    public class CUAltaDisciplina : ICUAltaDisciplina
    {

        IRepositorioDisciplina _repoDisciplina;
        IRepositorioAuditoria _auditoria;

        public CUAltaDisciplina(IRepositorioDisciplina repositorioDisciplina, IRepositorioAuditoria auditoria)
        {
            _repoDisciplina = repositorioDisciplina;
            _auditoria = auditoria;
        }


        public void AltaDisciplina(DtoDisciplina dto, string email)
        {
            Disciplina disciplinaEncontradaPorNombre = _repoDisciplina.FindByName(dto.Nombre);
            Disciplina disciplinaEncontradaPorCodigo = _repoDisciplina.FindByCode(dto.Codigo);

            if (disciplinaEncontradaPorNombre != null)
            {
                throw new AgregarDisciplinaNombreYaExisteException("Ya existe una disciplina con ese nombre");
            }
            else if (disciplinaEncontradaPorNombre == null) 
            {
             if(disciplinaEncontradaPorCodigo != null) 
                {
                 throw new AgregarDisciplinaCodigoYaExisteException("El codigo tiene que ser unico");
                }
                else if(disciplinaEncontradaPorCodigo == null) 
                {

                    Disciplina disciplina = MapperDisciplina.FromDtoDisciplinaToDisciplina(dto);
                    int id = _repoDisciplina.AddWithInt(disciplina);
                    Auditoria nuevaAuditoria = new Auditoria(DateTime.Now,disciplina.GetType().Name,"Alta",id,email);
                    _auditoria.Add(nuevaAuditoria);
                }
            }



            
        }
    }
}
