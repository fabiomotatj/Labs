using AutoMapper;
using IOC.Dal.Interfaces;
using IOC.Ent;
using IOC.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.Dal.Implement
{
    public class UsuarioDal : BaseDal<UsuarioEnt,UsuarioVM>, IUsuarioDal
    {
        public List<UsuarioVM> GetUsuarios()
        {
            try
            {
                using (DataContext db = new DataContext())
                {
                    List<UsuarioEnt> lstEnt = db.Usuario.ToList();

                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<UsuarioEnt, UsuarioVM>();
                    });

                    IMapper iMapper = config.CreateMapper();

                    //return iMapper;

                    List<UsuarioVM> vm = iMapper.Map<List<UsuarioVM>>(lstEnt);

                    return vm;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }   
    }
}
