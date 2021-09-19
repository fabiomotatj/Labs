using AspNetCoreApiIOC.Ent;
using AspNetCoreApiIOC.VM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreApiIOC.Dal.Interfaces
{
    public interface IUsuarioDal:IRepository<UsuarioEnt,UsuarioVM>
    {
        public Task<IEnumerable<UsuarioVM>> ListaUsuario();

        public Task<IEnumerable<UsuarioVM>> ListaUsuarioPorPerfil(int idPerfil);

        public Task<SistemaPerfilVM> AddSistemaPerfil(SistemaPerfilVM sistemaPerfil);
    }
}
