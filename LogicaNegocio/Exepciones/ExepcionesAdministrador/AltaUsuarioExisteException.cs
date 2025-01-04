using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Exepciones.ExepcionesAdministrador
{
    public class AltaUsuarioExisteException: Exception
    {
        
            public AltaUsuarioExisteException() : base()
            {

            }

            public AltaUsuarioExisteException(string? message) : base(message)
            {
            }

            public AltaUsuarioExisteException(string? message, Exception? innerException) : base(message, innerException)
            {

            }
        
    }
}
