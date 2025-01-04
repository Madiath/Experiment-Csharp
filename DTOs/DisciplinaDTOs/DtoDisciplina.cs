using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DisciplinaDTOs
{
    public class DtoDisciplina
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, MinimumLength = 11, ErrorMessage ="El nombre tiene que ser mayor a 10 y menor a 100 caracteres")]
        public string Nombre { get; set; }
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingresar una fecha")]
        public DateTime? AnioDisciplina { get; set; }
        [Required(ErrorMessage = "Se necesita un codigo")]
        public string Codigo {  get; set; }
    }
}
