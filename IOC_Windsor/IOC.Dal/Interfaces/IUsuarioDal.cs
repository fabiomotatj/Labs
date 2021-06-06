using IOC.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.Dal.Interfaces
{
    public interface IUsuarioDal
    {
        List<UsuarioVM> GetUsuarios();
    }
}
