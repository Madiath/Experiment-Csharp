using DTOs.AtletaDTOs;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Mappers
{
    public class MapperDigitador
    {
        public static List<DtoListarAtletas> FromListAtletaToListDtoListarAtletas(List<Atleta> atl) 
        {
            List<DtoListarAtletas> ret = new List<DtoListarAtletas>();

            foreach (Atleta atleta in atl) 
            {
             DtoListarAtletas dtoListarAtletas = new DtoListarAtletas();
                dtoListarAtletas.id = atleta.Id;
                dtoListarAtletas.NombreCompleto = atleta.NombreCompleto;
                dtoListarAtletas.PaisNombre = atleta.Pais.Nombre;
                ret.Add(dtoListarAtletas);
            }
            return ret;
        }




    }
}
