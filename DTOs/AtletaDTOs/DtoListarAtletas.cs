using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.AtletaDTOs
{
    public class DtoListarAtletas
    {
        public int id {  get; set; }
        public string PaisNombre { get; set; }
        public string NombreCompleto { get; set; }
    }
}
