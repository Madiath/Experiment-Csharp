using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Auditoria
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Entidad { get; set; }

        public string Operacion { get; set; }

        public int IdEntidad { get; set; }

        public string MailUsuario { get; set; }

        public Auditoria()
        {
            
        }

        public Auditoria(DateTime fecha, string entidad, string operacion, int idEntidad, string mailUsuario)
        {
            Fecha = fecha;
            Entidad = entidad;
            Operacion = operacion;
            IdEntidad = idEntidad;
            MailUsuario = mailUsuario;
        }
    }
}
