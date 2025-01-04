using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Exepciones.ExepcionesDigitador
{
    public class AsociarDisYaTieneEsaDisciplinaAtletaException: Exception
    {
        public AsociarDisYaTieneEsaDisciplinaAtletaException() : base()
        {

        }

        public AsociarDisYaTieneEsaDisciplinaAtletaException(string? message) : base(message)
        {
        }

        public AsociarDisYaTieneEsaDisciplinaAtletaException(string? message, Exception? innerException) : base(message, innerException)
        {

        }
    }
}
