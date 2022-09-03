using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BRepository<TEntity> : IDisposable where TEntity : BaseModel
    {
        protected Repository<TEntity> _repository;

        public BRepository(Repository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task Add(TEntity entity)
        {
            await _repository.Add(entity);
        }

        public async Task Delete(Func<TEntity, bool> predicate)
        {
            await _repository.Delete(predicate);
        }

        public async Task Update(TEntity entity)
        {
            await _repository.Update(entity);
        }

        public async Task<TEntity> GetOne(params object[] Keys)
        {
            return await _repository.GetOne(Keys);
        }

        public async Task<List<TEntity>> GetListAll(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> includes = null)
        {
            return await _repository.GetListAll(predicate, includes);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
