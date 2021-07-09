using AutoMapper;
using IOC.Ent;
using IOC.VM;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IOC.Dal
{
    public class BaseDal<TEnt,TVm> where TEnt:class where TVm : class
    {
        ILog log = LogManager.GetLogger(typeof(BaseDal<TEnt, TVm>));

        private IMapper mapToEnt;

        private IMapper mapToVM;

        public BaseDal()
        {
            log.Debug("Instanciando a Dal e criando mappers");

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap(typeof(TEnt), typeof(TVm));
            });

            mapToVM = config.CreateMapper();

            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap(typeof(TVm), typeof(TEnt));
            });

            mapToEnt = config.CreateMapper();

            log.Debug("instanciou a Dal e criando mappers");

        }
        public List<TVm> GetByFilter(Expression<Func<TEnt, bool>> predicate)
        {
            try
            {
                using (DataContext db = new DataContext())
                {

                    List<TEnt> list = db.Set<TEnt>().Where(predicate).ToList();

                    List<TVm> vm = mapToVM.Map<List<TVm>>(list);

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

                    log.Debug("--Metodo GetPaged--");

                    List<TEnt> list;

                    log.Debug("Consultando...");

                    if (predicate != null)
                        list = db.Set<TEnt>().Where(predicate).OrderBy(x=> 1).Skip(page == 1 ? 0 : (take * page) - take).Take(take).ToList();
                    else
                        list = db.Set<TEnt>().OrderBy(x => 1).Skip(page==1?0: (take * page) - take).Take(take).ToList();

                    log.Debug("Retornou consulta...");

                    List<TVm> vm = mapToVM.Map<List<TVm>>(list);

                    log.Debug("Retornando lista - " + vm.Count + " objetos");

                    return vm;

                }
            }
            catch (Exception ex)
            {
                log.Error("Erro no Método GetPaged",ex);
                throw ex;
            }
        }

        public TVm Add(TVm obj)
        {
            try
            {
                using (DataContext db = new DataContext())
                {


                    TEnt ent = mapToEnt.Map<TEnt>(obj);

                    db.Set<TEnt>().Add(ent);

                    db.SaveChanges();

                    obj = mapToVM.Map<TVm>(ent);

                    return obj;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(TVm obj, int id)
        {
            try
            {
                using (DataContext db = new DataContext())
                {

                    TEnt ent = mapToEnt.Map<TEnt>(obj);

                    db.Entry(ent).State = EntityState.Modified;

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
