using Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository<TEntity> where TEntity : BaseModel
    {
        Task Add(TEntity entity);
        Task Delete(Func<TEntity, bool> predicate);
        Task Update(TEntity entity);
        Task<TEntity> GetOne(params object[] Keys);
        Task<List<TEntity>> GetListAll(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> includes);
    }
}
