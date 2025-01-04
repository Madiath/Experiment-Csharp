using DTOs.Mappers;
using DTOs.UsuarioDTOs;
using LogicaAplicacion.InterfaceCU.ICUUsuario;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUUsuario
{
    
    public class CUListarUsuarios:ICUListarUsuarios
    {
        private IRepositorioUsuario _repositorioUsuarios;

        public CUListarUsuarios(IRepositorioUsuario repoUsuarios) 
        {
         _repositorioUsuarios = repoUsuarios;
        }

        public List<DtoListarUsuarios> ListarUsuarios()
        {
            List<DtoListarUsuarios> listaUsuarios = MapperUsuario.FromListUsuarioToListDtoListaUsuario(_repositorioUsuarios.FindAll());
            return listaUsuarios;
        }
    }
}
