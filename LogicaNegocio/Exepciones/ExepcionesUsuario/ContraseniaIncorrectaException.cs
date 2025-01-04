using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Exepciones.ExepcionesUsuario
{
    public class ContraseniaIncorrectaException: Exception
    {
        public ContraseniaIncorrectaException() : base()
        {

        }

        public ContraseniaIncorrectaException(string? message) : base(message)
        {
        }

        public ContraseniaIncorrectaException(string? message, Exception? innerException) : base(message, innerException)
        {

        }
    }
}
