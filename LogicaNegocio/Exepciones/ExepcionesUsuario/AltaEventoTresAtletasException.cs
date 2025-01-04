using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Exepciones.ExepcionesUsuario
{
    public class AltaEventoTresAtletasException: Exception
    {
        public AltaEventoTresAtletasException() : base()
        {

        }

        public AltaEventoTresAtletasException(string? message) : base(message)
        {
        }

        public AltaEventoTresAtletasException(string? message, Exception? innerException) : base(message, innerException)
        {

        }
    }
}
