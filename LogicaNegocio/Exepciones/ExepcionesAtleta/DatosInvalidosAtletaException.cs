using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Exepciones.ExepcionesAtleta
{
    public class DatosInvalidosAtletaException : Exception
    {
        public DatosInvalidosAtletaException() : base()
        {

        }

        public DatosInvalidosAtletaException(string? message) : base(message)
        {

        }

        public DatosInvalidosAtletaException(string? message, Exception? innerException) : base(message, innerException)
        {

        }
    }
}
