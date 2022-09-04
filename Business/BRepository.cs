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
   
        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
