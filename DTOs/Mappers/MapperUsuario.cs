using DTOs.UsuarioDTOs;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Mappers
{
    public class MapperUsuario
    {
        public static Usuario FromDtoUsuarioToUsuario(DtoAltaUsuario dto) 
        {
          Usuario user = new Usuario();
            user.Email = dto.Email;
            user.Contrasenia = dto.Contrasenia;
            user.Rol = dto.Rol;
            user.FechaIngreso = dto.FechaIngreso;
            user.AdminQueDioAltaId = dto.IdAdmin;
            return user;
        }

        public static List<DtoListarUsuarios> FromListUsuarioToListDtoListaUsuario(List<Usuario> l)
        {

            List<DtoListarUsuarios> ret = new List<DtoListarUsuarios>();
            foreach (Usuario usuario in l)
            {
                DtoListarUsuarios u = new DtoListarUsuarios();
                u.id = usuario.Id;
                u.Email = usuario.Email;
                u.Rol = usuario.Rol;
                u.FechaIngreso = usuario.FechaIngreso;
                u.AdminQueDioAltaId = usuario.AdminQueDioAltaId;

                ret.Add(u);

            }

            return ret;
        }

    }
}
