using RaceManager.Server.DataAccess.Core.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RaceManager.Server.DataAccess.Core.Repositories
{
    interface IRepository<TDataAccessObject> where TDataAccessObject : DataAccessObject
    {
        TDataAccessObject Get(int id);
        IEnumerable<TDataAccessObject> GetAll();
        TDataAccessObject Find(Expression<Func<TDataAccessObject, bool>> predicate);
        IEnumerable<TDataAccessObject> FindAll(Expression<Func<TDataAccessObject, bool>> predicate);
        void Add(TDataAccessObject dao);
        void AddRange(IEnumerable<TDataAccessObject> daos);
        void Remove(int id);
        void Remove(TDataAccessObject dao);
    }
}
