using IOC.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.Bus.Interfaces
{
    public interface IUsuarioBus
    {
        List<UsuarioVM> GetUsuarios();
        List<UsuarioVM> GetPaged(int page, int take);
        int Add(UsuarioVM usuario);
        void Update(UsuarioVM obj, int id);
    }
}
