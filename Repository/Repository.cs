using Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Repository<TEntity> : IDisposable where TEntity : BaseModel
    {
        protected SolutionContext _db;

        public Repository(SolutionContext db)
        {
            _db = db;
        }

        protected async Task Add(TEntity entity)
        {
            entity = BeforAdd(entity);
            using (var tc = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.Entry(entity).State = EntityState.Added;
                    await _db.SaveChangesAsync();
                    tc.Commit();
                    ClearEntityCache();
                }
                catch (Exception ex)
                {
                    tc.Rollback();
                    throw new Exception(ex.InnerException.InnerException.Message.ToString());
                }
            }
        }

        protected async Task Delete(Func<TEntity, bool> predicate)
        {
            using (var tc = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.Set<TEntity>().Where(predicate).ToList().ForEach(del => _db.Set<TEntity>().Remove(del));
                    await _db.SaveChangesAsync();
                    tc.Commit();
                }
                catch (Exception ex)
                {
                    tc.Rollback();
                    throw new Exception(ex.InnerException.InnerException.Message.ToString());
                }
            }
        }

        protected async Task<List<TEntity>> GetListAll(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> includes = null)
        {
            if (includes != null)
                return await _db.Set<TEntity>().Where(predicate).Include(includes).ToListAsync();
            else
                return await _db.Set<TEntity>().Where(predicate).ToListAsync();
        }

        protected async Task<TEntity> GetOne(params object[] Keys)
        {
            return await _db.Set<TEntity>().FindAsync(Keys);
        }

        protected async Task Update(TEntity entity)
        {
            entity = BeforUpdate(entity);
            using (var tc = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.Entry(entity).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                    tc.Commit();
                    ClearEntityCache();
                }
                catch (Exception ex)
                {
                    tc.Rollback();
                    throw new Exception(ex.InnerException.InnerException.Message.ToString());
                }
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        private TEntity BeforUpdate(TEntity entity)
        {
            entity.UserIDLastUpdate = 1;
            entity.ModifieldDate = DateTime.Now;

            return entity;
        }

        private void ClearEntityCache()
        {
            try
            {
                foreach (EntityEntry dbEntityEntry in _db.ChangeTracker.Entries())
                    if (dbEntityEntry.Entity != null)
                        dbEntityEntry.State = EntityState.Detached;
            }
            catch
            {
            }
        }

        private TEntity BeforAdd(TEntity entity)
        {
            entity.UserIDLastUpdate = 1;
            entity.UserID = 1;
            entity.ModifieldDate = DateTime.Now;
            entity.CreateDate = DateTime.Now;

            return entity;
        }
    }
}
