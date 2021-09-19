using AspNetCoreApiIOC.Dal.Implement;
using AspNetCoreApiIOC.Dal.Interfaces;
using AspNetCoreApiIOC.VM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AspNetCoreApiIOC.Bus
{
    public class UsuarioBus
    {
        IUsuarioDal _usuarioDal;
        public UsuarioBus(IUsuarioDal usuarioDal)
        {
            _usuarioDal = usuarioDal;
        }

        public async Task<IEnumerable<UsuarioVM>> ListaUsuarios()
        {
            var ret = await _usuarioDal.ListaUsuario();

            return ret;
        }

        public async Task<UsuarioVM> Add(UsuarioVM usuario)
        {
            try
            {
                var usu = await _usuarioDal.Add(usuario);

                return usu;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SistemaPerfilVM> AddSistemaPerfil(SistemaPerfilVM sistemaPerfil)
        {
            try
            {
                var ret = await _usuarioDal.AddSistemaPerfil(sistemaPerfil);

                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
