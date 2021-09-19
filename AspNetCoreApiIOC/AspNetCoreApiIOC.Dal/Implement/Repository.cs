using AspNetCoreApiIOC.Dal.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreApiIOC.Dal.Implement
{
    public class Repository<TEnt, TVm>:IRepository<TEnt, TVm> where TEnt : class where TVm : class
    {
        
        protected IMapper mapToEnt;

        protected IMapper mapToVM;

        protected DataContext _dataContext;
        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;

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

        }
        public async Task<List<TVm>> GetByFilter(Expression<Func<TEnt, bool>> predicate, int page, int take)
        {
            try
            {
                var list = await _dataContext.Set<TEnt>().Where(predicate).ToListAsync();

                List<TVm> vm = mapToVM.Map<List<TVm>>(list);

                return vm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<TVm> GetById(int id)
        {
            try
            {
                var ent = await _dataContext.Set<TEnt>().FindAsync(id);

                TVm vm = mapToVM.Map<TVm>(ent);

                return vm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<TVm> Add(TVm obj)
        {
            try
            {
                TEnt ent = mapToEnt.Map<TEnt>(obj);

                await _dataContext.Set<TEnt>().AddAsync(ent);

                await _dataContext.SaveChangesAsync();

                obj = mapToVM.Map<TVm>(ent);

                return obj;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<TVm> Update(TVm obj, int id)
        {
            try
            {
                

                TEnt ent = mapToEnt.Map<TEnt>(obj);

                _dataContext.Entry(ent).State = EntityState.Modified;

                await _dataContext.SaveChangesAsync();

                return obj;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task Delete(TVm obj, int id)
        {

        }
    }
}
