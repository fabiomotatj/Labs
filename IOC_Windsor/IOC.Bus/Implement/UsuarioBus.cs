using IOC.Bus.Interfaces;
using IOC.Dal.Interfaces;
using IOC.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.Bus.Implement
{
    public class UsuarioBus: IUsuarioBus
    {

        private IUsuarioDal _usuarioDal;

        public UsuarioBus(IUsuarioDal usuarioDal)
        {
            _usuarioDal = usuarioDal;
        }

        public List<UsuarioVM> GetUsuarios()
        {
            return new List<UsuarioVM>();
        }
    }
}
