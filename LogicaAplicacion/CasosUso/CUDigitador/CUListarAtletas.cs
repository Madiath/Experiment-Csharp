using DTOs.AtletaDTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfaceCU.ICUDigitador;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUDigitador
{
    public class CUListarAtletas : ICUListarAtletas
    {
        private IRepositorioAtleta _repoAtletas;
        

        public CUListarAtletas(IRepositorioAtleta repoAtletas) 
        {
         _repoAtletas = repoAtletas;
        }

        public List<DtoListarAtletas> ListarAtletas()
        {
            List<DtoListarAtletas> dtoListarAtletas = MapperDigitador.FromListAtletaToListDtoListarAtletas(_repoAtletas.FindAll());
            return dtoListarAtletas;
        }
    }
}
