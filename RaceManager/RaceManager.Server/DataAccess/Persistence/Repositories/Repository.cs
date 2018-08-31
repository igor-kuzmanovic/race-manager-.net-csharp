using RaceManager.Server.DataAccess.Core.DataAccessObjects;
using RaceManager.Server.DataAccess.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace RaceManager.Server.DataAccess.Persistence.Repositories
{
    abstract class Repository<TDataAccessObject> : IRepository<TDataAccessObject> where TDataAccessObject : DataAccessObject
    {
        protected readonly RaceManagerDbContext _context;
        protected readonly DbSet<TDataAccessObject> dbSet;

        public Repository(RaceManagerDbContext context)
        {
            _context = context;
            dbSet = _context.Set<TDataAccessObject>();
        }

        public virtual TDataAccessObject Get(int id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<TDataAccessObject> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual TDataAccessObject Find(Expression<Func<TDataAccessObject, bool>> predicate)
        {
            return dbSet.SingleOrDefault(predicate);
        }

        public virtual IEnumerable<TDataAccessObject> FindAll(Expression<Func<TDataAccessObject, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public virtual void Add(TDataAccessObject dao)
        {
            dbSet.Add(dao);
        }

        public virtual void AddRange(IEnumerable<TDataAccessObject> daos)
        {
            dbSet.AddRange(daos);
        }

        public virtual void Remove(int id)
        {
            dbSet.Remove(dbSet.Find(id));
        }

        public virtual void Remove(TDataAccessObject dao)
        {
            dbSet.Remove(dao);
        }
    }
}