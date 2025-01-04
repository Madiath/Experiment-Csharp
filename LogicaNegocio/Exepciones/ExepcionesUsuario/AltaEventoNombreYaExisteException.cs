using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Exepciones.ExepcionesUsuario
{
    public class AltaEventoNombreYaExisteException: Exception
    {
        public AltaEventoNombreYaExisteException() : base()
        {

        }

        public AltaEventoNombreYaExisteException(string? message) : base(message)
        {
        }

        public AltaEventoNombreYaExisteException(string? message, Exception? innerException) : base(message, innerException)
        {

        }
    }
}
