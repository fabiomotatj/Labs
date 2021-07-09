using IOC.Ent;
using IOC.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IOC.Dal.Interfaces
{
    public interface IUsuarioDal
    {
        List<UsuarioVM> GetUsuarios();
        List<UsuarioVM> GetByFilter(Expression<Func<UsuarioEnt, bool>> predicate);
        List<UsuarioVM> GetPaged(Expression<Func<UsuarioEnt, bool>> predicate, int page, int take);
        UsuarioVM Add(UsuarioVM obj);
        void Update(UsuarioVM obj, int id);
    }
}
