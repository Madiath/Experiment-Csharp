using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Exepciones.ExepcionesDisciplina
{
    public class DatosInvalidosDisciplinaException : Exception
    {
        public DatosInvalidosDisciplinaException() : base()
        {

        }

        public DatosInvalidosDisciplinaException(string? message) : base(message)
        {

        }

        public DatosInvalidosDisciplinaException(string? message, Exception? innerException) : base(message, innerException)
        {

        }
    }
}
