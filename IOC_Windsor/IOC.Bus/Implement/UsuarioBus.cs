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
            try
            {
                return _usuarioDal.GetPaged(null,1,2);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int Add(UsuarioVM usuario)
        {
            try
            {
                return _usuarioDal.Add(usuario).Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(UsuarioVM usuario, int id)
        {
            try
            {
                 _usuarioDal.Update(usuario, id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<UsuarioVM> GetPaged(int page, int take)
        {
            try
            {
                return _usuarioDal.GetPaged(null, page, take);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
