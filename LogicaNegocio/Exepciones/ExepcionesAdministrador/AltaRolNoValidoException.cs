using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Exepciones.ExepcionesAdministrador
{
    public class AltaRolNoValidoException: Exception
    {
        public AltaRolNoValidoException() : base()
        {

        }

        public AltaRolNoValidoException(string? message) : base(message)
        {
        }

        public AltaRolNoValidoException(string? message, Exception? innerException) : base(message, innerException)
        {

        }
    }
}
