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
        DriverDTO Get(int id);

        [OperationContract]
        IEnumerable<DriverDTO> GetAll();

        [OperationContract]
        void Add(DriverDTO dto);

        [OperationContract]
        void Update(DriverDTO dto);

        [OperationContract]
        void Remove(int id);
    }
}
