using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreApiIOC.Dal.Interfaces
{
    public interface IRepository<TEnt, TVm> where TEnt : class where TVm : class
    {
        public Task<List<TVm>> GetByFilter(Expression<Func<TEnt, bool>> predicate, int page, int take);
        public Task<TVm> GetById(int id);
        public Task<TVm> Add(TVm obj);
        public Task<TVm> Update(TVm obj, int id);
        public Task Delete(TVm obj, int id);
    }
}
