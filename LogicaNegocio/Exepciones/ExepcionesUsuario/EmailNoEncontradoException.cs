using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Exepciones.ExepcionesUsuario
{
    public class EmailNoEncontradoException : Exception
    {
        public EmailNoEncontradoException() : base()
        {

        }

        public EmailNoEncontradoException(string? message) : base(message)
        {
        }

        public EmailNoEncontradoException(string? message, Exception? innerException) : base(message, innerException)
        {

        }
    }
}
