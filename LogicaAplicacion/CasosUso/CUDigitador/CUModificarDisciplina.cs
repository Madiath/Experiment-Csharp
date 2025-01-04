using DTOs.DisciplinaDTOs;
using LogicaAplicacion.InterfaceCU.ICUDigitador;
using LogicaNegocio.Entidades;
using LogicaNegocio.Exepciones.ExepcionesDisciplina;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUDigitador
{
    public class CUModificarDisciplina : ICUModificarDisciplina
    {
        IRepositorioDisciplina _repoDisciplina;
        IRepositorioAuditoria _auditoria;
        public CUModificarDisciplina(IRepositorioDisciplina repoDisciplina,IRepositorioAuditoria auditoria)
        {
            _repoDisciplina = repoDisciplina;
            _auditoria = auditoria;
        }
        public void ModificarDisciplina(DtoAltaDisciplina dto,string email)
        {
                Disciplina disciplinaEncontrada = _repoDisciplina.FindById(dto.id);

            disciplinaEncontrada.AnioDisciplina = dto.anioDisciplina;
            disciplinaEncontrada.Codigo = dto.codigo;
            disciplinaEncontrada.Nombre = dto.nombre;
           

                _repoDisciplina.Update(disciplinaEncontrada);
                Auditoria nuevaAuditoria = new Auditoria(DateTime.Now, disciplinaEncontrada.GetType().Name, "Modificacion", disciplinaEncontrada.Id, email);
                _auditoria.Add(nuevaAuditoria);   
        }
    }
}
