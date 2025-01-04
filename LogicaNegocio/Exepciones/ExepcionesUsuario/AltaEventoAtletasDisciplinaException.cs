using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Exepciones.ExepcionesUsuario
{
    public class AltaEventoAtletasDisciplinaException:Exception
    {
        public AltaEventoAtletasDisciplinaException() : base()
        {

        }

        public AltaEventoAtletasDisciplinaException(string? message) : base(message)
        {
        }

        public AltaEventoAtletasDisciplinaException(string? message, Exception? innerException) : base(message, innerException)
        {

        }
    }
}
