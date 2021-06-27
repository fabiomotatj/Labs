using AutoMapper;
using IOC.Ent;
using IOC.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IOC.Dal
{
    public class BaseDal<TEnt,TVm> where TEnt:class where TVm : class
    {
        public List<TVm> GetByFilter(Expression<Func<TEnt, bool>> predicate)
        {
            try
            {
                using (DataContext db = new DataContext())
                {

                    List<TEnt> list = db.Set<TEnt>().Where(predicate).ToList();

                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap(typeof(TEnt), typeof(TVm));
                    });

                    IMapper iMapper = config.CreateMapper();

                    //return iMapper;

                    List<TVm> vm = iMapper.Map<List<TVm>>(list);

                    return vm;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TVm> GetPaged(Expression<Func<TEnt, bool>> predicate, int page, int take)
        {
            try
            {
                using (DataContext db = new DataContext())
                {

                    List<TEnt> list;

                    if(predicate != null)
                        list = db.Set<TEnt>().Where(predicate).OrderBy(x=> 1).Skip(page == 1 ? 0 : (take * page) - take).Take(take).ToList();
                    else
                        list = db.Set<TEnt>().OrderBy(x => 1).Skip(page==1?0: (take * page) - take).Take(take).ToList();

                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap(typeof(TEnt), typeof(TVm));
                    });

                    IMapper iMapper = config.CreateMapper();

                    //return iMapper;

                    List<TVm> vm = iMapper.Map<List<TVm>>(list);

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
