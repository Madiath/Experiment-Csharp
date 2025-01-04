using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public  class Usuario
    {
        public int Id { get; set; }
        
        public string Email { get; set; }
        public string Contrasenia { get; set; }

        public string Rol {  get; set; }

        public DateTime FechaIngreso { get; set; }
        public int? AdminQueDioAltaId { get; set; }



    }
}
