using TemplateMVC.Ent;
using TemplateMVC.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace TemplateMVC.Dal
{
    public class UsuarioDal
    {
        public static List<UsuarioVM> RetUsuarios()
        {
            try
            {
                using (DataContext db = new DataContext())
                {
                    List<UsuarioEnt> lstEnt = db.Usuario.ToList();

                    var config = new MapperConfiguration(cfg => {
                        cfg.CreateMap<List<UsuarioEnt>, List<UsuarioVM>>();
                    });

                    IMapper iMapper = config.CreateMapper();

                    return iMapper.Map<List<UsuarioVM>>(lstEnt);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
