using RaceManagerServer.DataAccess.Core.Domain;
using RaceManagerServer.DataAccess.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace RaceManagerServer.DataAccess.Persistence.Repositories
{
    abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly RaceManagerContext _context;
        protected readonly DbSet<TEntity> dbSet;

        public Repository(RaceManagerContext context)
        {
            _context = context;
            dbSet = _context.Set<TEntity>();
        }

        public virtual TEntity Get(int id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.SingleOrDefault(predicate);
        }

        public virtual IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public virtual void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            dbSet.AddRange(entities);
        }

        public virtual void Remove(int id)
        {
            dbSet.Remove(dbSet.Find(id));
        }

        public virtual void Remove(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}