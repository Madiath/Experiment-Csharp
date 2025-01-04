using LogicaAplicacion.InterfaceCU.ICUUsuario;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUEliminarDisciplina : ICUEliminarDisciplina
    {

        IRepositorioDisciplina _repoDisciplina;
        IRepositorioAuditoria _auditoria;
        public CUEliminarDisciplina(IRepositorioDisciplina repoDisciplina, IRepositorioAuditoria auditoria)
        {
            _repoDisciplina = repoDisciplina;
            _auditoria = auditoria;
        }

        public void EliminarDisciplina(int id, string email)
        {
            Disciplina disciplinaEncontrada = _repoDisciplina.FindById(id);
            _repoDisciplina.Remove(id);
            Auditoria nuevaAuditoria = new Auditoria(DateTime.Now, disciplinaEncontrada.GetType().Name, "Baja", id, email);
            _auditoria.Add(nuevaAuditoria);
        }
    }
}
