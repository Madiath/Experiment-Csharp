using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Exepciones.ExepcionesDisciplina
{
    public class NoAtletasDisciplinaException  : Exception
    {

        public NoAtletasDisciplinaException() : base()
        {

        }

        public NoAtletasDisciplinaException(string? message) : base(message)
        {

        }

        public NoAtletasDisciplinaException(string? message, Exception? innerException) : base(message, innerException)
        {

        }
    }
}
