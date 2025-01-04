using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.UsuarioDTOs
{
    public class DtoListarUsuarios
    {
        public int id {  get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }

        public DateTime FechaIngreso { get; set; }
        public int? AdminQueDioAltaId { get; set; }


    }
}
