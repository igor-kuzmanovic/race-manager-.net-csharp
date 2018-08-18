using Service;
using System;
using System.Collections.Generic;

namespace Server
{
    abstract class BaseCRUDService<TDataTransferObject, TEntity> : ICRUDService<TDataTransferObject>
    {
        public virtual IEnumerable<TDataTransferObject> GetAll(string securityToken)
        {
            throw new NotImplementedException();
        }

        public virtual TDataTransferObject Get(string securityToken, int id)
        {
            throw new NotImplementedException();
        }

        public virtual int Insert(string securityToken, TDataTransferObject dto)
        {
            throw new NotImplementedException();
        }

        public virtual bool Update(string securityToken, TDataTransferObject dto)
        {
            throw new NotImplementedException();
        }

        public virtual bool Delete(string securityToken, int id)
        {
            throw new NotImplementedException();
        }
    }
}
