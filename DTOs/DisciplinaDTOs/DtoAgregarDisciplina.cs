using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DisciplinaDTOs
{
    public class DtoAgregarDisciplina
    {
        public int IdAtleta { get; set; } 
        public List<int> IdsDisciplinas { get; set; }

        public List<DtoDisciplina> ListaDisciplina { get; set; }
    }
}
