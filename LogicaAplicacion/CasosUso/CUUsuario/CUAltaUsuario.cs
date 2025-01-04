using DTOs.Mappers;
using DTOs.UsuarioDTOs;
using LogicaAplicacion.InterfaceCU;
using LogicaNegocio.Entidades;
using LogicaNegocio.Exepciones.ExepcionesAdministrador;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUAltaUsuario : ICUAltaUsuario
    {
        private IRepositorioUsuario _Usuarios;
        
        public CUAltaUsuario(IRepositorioUsuario usuarios)
        {
            _Usuarios = usuarios;
        }
        public void AltaUsuario(DtoAltaUsuario dto)
        {
            Usuario usuarioExistente = _Usuarios.FindByGmail(dto.Email);
            if (usuarioExistente != null)
            {
                throw new AltaUsuarioExisteException("Ya existe un usuario con ese mail");
            }
            else if (usuarioExistente == null) 
            {
                if (dto.Rol.Equals("Digitador") || dto.Rol.Equals("Administrador"))
                {
                    Usuario nuevoUsuario = MapperUsuario.FromDtoUsuarioToUsuario(dto);
                    _Usuarios.Add(nuevoUsuario);
                }
                else
                {
                  throw new AltaRolNoValidoException("Por favor, ingresar un rol valido");
                }
            }
        }
    }
}
