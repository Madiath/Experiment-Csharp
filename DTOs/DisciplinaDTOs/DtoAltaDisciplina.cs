using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DisciplinaDTOs
{
    public class DtoAltaDisciplina
    {
       public string nombre { get; set; }
        public int id { get; set; }
      
        public DateTime? anioDisciplina { get; set; }
        
        public string codigo { get; set; }
    }
}
