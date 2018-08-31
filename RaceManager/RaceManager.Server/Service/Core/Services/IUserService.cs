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
        UserDTO Get(string token, int id);

        [OperationContract]
        IEnumerable<UserDTO> GetAll(string token);

        [OperationContract]
        bool Add(string token, UserDTO dto);

        [OperationContract]
        bool Update(string token, UserDTO dto);

        [OperationContract]
        bool Remove(string token, int id);
    }
}
