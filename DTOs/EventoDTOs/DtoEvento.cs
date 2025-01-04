using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.EventoDTOs
{
    public class DtoEvento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Disciplina Disciplina { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin {  get; set; }
    }
}
