using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Exepciones.ExepcionesDigitador
{
    public class AgregarDisciplinaCodigoYaExisteException:Exception
    {
        public AgregarDisciplinaCodigoYaExisteException() : base()
        {

        }

        public AgregarDisciplinaCodigoYaExisteException(string? message) : base(message)
        {
        }

        public AgregarDisciplinaCodigoYaExisteException(string? message, Exception? innerException) : base(message, innerException)
        {

        }
    }
}
