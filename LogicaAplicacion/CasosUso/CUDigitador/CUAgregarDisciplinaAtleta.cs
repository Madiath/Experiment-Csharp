using DTOs.DisciplinaDTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfaceCU.ICUDigitador;
using LogicaNegocio.Entidades;
using LogicaNegocio.Exepciones.ExepcionesDigitador;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUDigitador
{
    public class CUAgregarDisciplinaAtleta : ICUAgregarDisciplina
    {

        private IRepositorioDisciplina _disciplinas;
        private IRepositorioAtleta _atletas;

        public CUAgregarDisciplinaAtleta(IRepositorioDisciplina repoDisciplinas, IRepositorioAtleta repoAtletas)
        {
            _disciplinas = repoDisciplinas;
            _atletas = repoAtletas;
        }

        //Mandar los datos para asociar
        public DtoAgregarDisciplina AgregarDisciplina(int idAtleta)
        {
            List<Disciplina> disciplinas = _disciplinas.FindAll();

            List<DtoDisciplina> dtoDisciplinas = MapperDisciplina.FromListDisciplinaToListDtoDisciplina(disciplinas);

            DtoAgregarDisciplina dtoAgregarDisciplinas = new DtoAgregarDisciplina();

            dtoAgregarDisciplinas.ListaDisciplina = dtoDisciplinas;
            dtoAgregarDisciplinas.IdAtleta = idAtleta;
            return dtoAgregarDisciplinas ;
            
        }

        //Asociar
        public void PostAgregarDisciplina(int idAtleta, List<int> idDisciplinas) 
        {
            Atleta atleta = _atletas.FindByIdWithDisciplinas(idAtleta);

            List<Disciplina> disciplinasAsociadas = new List<Disciplina>();

            foreach (int idDi in idDisciplinas) 
            {
                Disciplina disciplinaBuscada = _disciplinas.FindById(idDi);
                disciplinasAsociadas.Add(disciplinaBuscada);
               // disciplinaBuscada.ListaAtletas.Add(atleta);
                //disciplinasAsociadas.Add(disciplinaBuscada);
            
            }

            foreach (Disciplina di in disciplinasAsociadas) 
            {
                foreach (Disciplina diAtl in atleta._listaDisiplinas) 
                {
                    if (di.Nombre == diAtl.Nombre) 
                    {
                        throw new AsociarDisYaTieneEsaDisciplinaAtletaException(di.Nombre);
                    }
                }
            }


            atleta._listaDisiplinas = disciplinasAsociadas;
            _atletas.Update(atleta);

        }


    }
}
