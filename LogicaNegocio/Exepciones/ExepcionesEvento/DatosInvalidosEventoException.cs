using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Exepciones.ExepcionesEvento
{
    public class DatosInvalidosEventoException : Exception
    {

        public DatosInvalidosEventoException() : base()
        {

        }

        public DatosInvalidosEventoException(string? message) : base(message)
        {

        }

        public DatosInvalidosEventoException(string? message, Exception? innerException) : base(message, innerException)
        {

        }
    }
}
