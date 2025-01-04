using DTOs.Mappers;
using DTOs.UsuarioDTOs;
using LogicaAplicacion.InterfaceCU.ICUUsuario;
using LogicaNegocio.Entidades;
using LogicaNegocio.Exepciones.ExepcionesUsuario;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUUsuarioLogin : ICUUsuarioLogin
    {
        private IRepositorioUsuario _usuarios;

        public CUUsuarioLogin(IRepositorioUsuario repoUsuarios)
        {
            _usuarios = repoUsuarios;
        }
        public DtoUsuarioLogin Login(DtoUsuarioLogin dto)
        {
            DtoUsuarioLogin retorno = null;

            Usuario buscado = _usuarios.FindByGmail(dto.Email);

            if (buscado != null)
            {
                if (buscado.Contrasenia == dto.Password)
                {
                    dto.IdUsuario = buscado.Id;
                    dto.Email = buscado.Email;
                    dto.Rol = buscado.Rol;
                    dto.Password = "";
                    retorno = dto;
                }
                else if(buscado.Contrasenia != dto.Password) 
                {
                    throw new ContraseniaIncorrectaException("Contrasenia incorrecta");
                }
            }
            else if(buscado == null)
            {
                throw new EmailNoEncontradoException("Usuario no encontrado");
            }

            return retorno;
        }

        public DtoUsuarioLogin LoginCliente(DtoLogin dto)
        {

            DtoUsuarioLogin retorno = new DtoUsuarioLogin();

            Usuario buscado = _usuarios.FindByGmail(dto.Email);

            if (buscado != null)
            {
                if (buscado.Contrasenia == dto.Password)
                {
                    retorno.IdUsuario = buscado.Id;
                    retorno.Email = buscado.Email;
                    retorno.Rol = buscado.Rol;
                    retorno.Password = "";
                }
                else if (buscado.Contrasenia != dto.Password)
                {
                    throw new ContraseniaIncorrectaException("Contrasenia incorrecta");
                }
            }
            else if (buscado == null)
            {
                throw new EmailNoEncontradoException("Usuario no encontrado");
            }

            return retorno;
        }
    }
}
