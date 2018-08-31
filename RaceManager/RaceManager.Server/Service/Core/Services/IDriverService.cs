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
    public interface IDriverService
    {
        [OperationContract]
        DriverDTO Get(string token, int id);

        [OperationContract]
        IEnumerable<DriverDTO> GetAll(string token);

        [OperationContract]
        bool Add(string token, DriverDTO dto);

        [OperationContract]
        bool Update(string token, DriverDTO dto);

        [OperationContract]
        bool Remove(string token, int id);
    }
}
