using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ServiceModel;

namespace Service
{
    public interface ICRUDService<TDataTransferObject>
    {
        [OperationContract]
        IEnumerable<TDataTransferObject> GetAll(string securityToken);

        [OperationContract]
        TDataTransferObject Get(string securityToken, int id);

        [OperationContract]
        int Insert(string securityToken, TDataTransferObject dto);

        [OperationContract]
        bool Update(string securityToken, TDataTransferObject dto);

        [OperationContract]
        bool Delete(string securityToken, int id);
    }
}
