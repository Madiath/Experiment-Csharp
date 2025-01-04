using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Exepciones.ExepcionesDisciplina
{
    public class DisciplinaNoEncontradaException : Exception
    {
        public DisciplinaNoEncontradaException() : base()
        {

        }

        public DisciplinaNoEncontradaException(string? message) : base(message)
        {

        }

        public DisciplinaNoEncontradaException(string? message, Exception? innerException) : base(message, innerException)
        {

        }

    }
}
