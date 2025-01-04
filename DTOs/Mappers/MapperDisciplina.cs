using DTOs.DisciplinaDTOs;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Mappers
{
    public class MapperDisciplina
    {
        public static Disciplina FromDtoDisciplinaToDisciplina(DtoDisciplina dto) 
        {
            Disciplina disciplina = new Disciplina();
            disciplina.Nombre = dto.Nombre;
            disciplina.Id = dto.Id;
            disciplina.AnioDisciplina = dto.AnioDisciplina;
            disciplina.Codigo = dto.Codigo;
            return disciplina;
            
        }


        public static DtoDisciplina FromDisciplinaToDtoDisciplina(Disciplina dto)
        {
            DtoDisciplina disciplina = new DtoDisciplina();
            disciplina.Nombre = dto.Nombre;
            disciplina.Id = dto.Id;
            disciplina.AnioDisciplina = dto.AnioDisciplina;
            disciplina.Codigo = dto.Codigo;
            return disciplina;

        }





        public static List<DtoDisciplina> FromListDisciplinaToListDtoDisciplina(List<Disciplina> di)
        {
            List<DtoDisciplina> ret = new List<DtoDisciplina>();
            foreach (Disciplina disciplina in di)
            {
                DtoDisciplina dtoDisciplina = new DtoDisciplina();
                dtoDisciplina.Id = disciplina.Id;
                dtoDisciplina.Nombre = disciplina.Nombre;
                dtoDisciplina.AnioDisciplina = disciplina.AnioDisciplina;
                dtoDisciplina.Codigo = disciplina.Codigo;
                ret.Add(dtoDisciplina);
            }
            return ret;
        }

    }
}
