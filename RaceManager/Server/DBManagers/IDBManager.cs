using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Server
{
    interface IDBManager<TEntity> where TEntity : BaseEntity
    {
        TEntity Find(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);
        int Insert(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(int id);
    }
}