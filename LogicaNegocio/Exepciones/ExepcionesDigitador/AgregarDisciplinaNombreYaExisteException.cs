using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Exepciones.ExepcionesDigitador
{
    public class AgregarDisciplinaNombreYaExisteException: Exception
    {
        public AgregarDisciplinaNombreYaExisteException() : base()
        {

        }

        public AgregarDisciplinaNombreYaExisteException(string? message) : base(message)
        {
        }

        public AgregarDisciplinaNombreYaExisteException(string? message, Exception? innerException) : base(message, innerException)
        {

        }
    }
}
