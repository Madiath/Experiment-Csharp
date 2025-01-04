using DTOs.AtletaDTOs;
using DTOs.DisciplinaDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.EventoDTOs
{
    public class DtoAltaEvento
    {
        public string Nombre { get; set; }
        public int DisciplinaID { get; set; }
        public List<int> AtletasID { get; set; }
        public List<DtoDisciplina> Disciplinas { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public List<DtoListarAtletas> Atletas { get; set; }
    }
}
