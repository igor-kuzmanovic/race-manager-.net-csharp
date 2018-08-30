using RaceManager.Server.Service.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RaceManager.Server.Service.Core.Services
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        UserDTO Get(int id);

        [OperationContract]
        IEnumerable<UserDTO> GetAll();

        [OperationContract]
        void Add(UserDTO dto);

        [OperationContract]
        void Update(UserDTO dto);

        [OperationContract]
        void Remove(int id);
    }
}
