using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Server
{
    abstract class BaseDBManager<TEntity> : IDBManager<TEntity> where TEntity : BaseEntity
    {
        public virtual TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            using (var context = new DBContext())
            {
                return context.Set<TEntity>().FirstOrDefault(predicate);
            }
        }

        public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            using (var context = new DBContext())
            {
                return context.Set<TEntity>().Where(predicate).ToList();
            }
        }

        public virtual int Insert(TEntity entity)
        {
            using (var context = new DBContext())
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
                return entity.Id;
            }
        }

        public virtual bool Update(TEntity entity)
        {
            using (var context = new DBContext())
            {
                var oldEntity = Get(e => e.Id == entity.Id);

                if (oldEntity == null)
                    return false;

                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }

        public virtual bool Delete(int id)
        {
            using (var context = new DBContext())
            {
                var entity = Get(e => e.Id == id);

                if (entity == null)
                    return false;

                context.Set<TEntity>().Remove(entity);
                context.SaveChanges();
                return true;
            }
        }
    }
}
