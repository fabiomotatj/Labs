using TemplateMVC.Dal;
using TemplateMVC.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMVC.Bus
{
    public class UsuarioBus
    {
        public static List<UsuarioVM> RetUsuarios()
        {
            try
            {
                return UsuarioDal.RetUsuarios();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
