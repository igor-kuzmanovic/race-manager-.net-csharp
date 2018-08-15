using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Server
{
    interface IDBManager<TEntity> where TEntity : BaseEntity
    {
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        int Insert(TEntity driver);
        bool Update(TEntity driver);
        bool Delete(int id);
    }
}