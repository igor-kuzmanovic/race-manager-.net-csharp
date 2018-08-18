using Service;
using System;
using System.Collections.Generic;

namespace Server
{
    abstract class BaseCRUDService<TDataTransferObject, TEntity> : ICRUDService<TDataTransferObject> where TEntity : BaseEntity
    {
        public abstract IEnumerable<TDataTransferObject> GetAll(string securityToken);

        public abstract TDataTransferObject Get(string securityToken, int id);

        public abstract int Insert(string securityToken, TDataTransferObject dto);

        public abstract bool Update(string securityToken, TDataTransferObject dto);

        public abstract bool Delete(string securityToken, int id);
    }
}
