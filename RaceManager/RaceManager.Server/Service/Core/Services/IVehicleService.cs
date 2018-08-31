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
    public interface IVehicleService
    {
        [OperationContract]
        VehicleDTO Get(string token, int id);

        [OperationContract]
        IEnumerable<VehicleDTO> GetAll(string token);

        [OperationContract]
        bool Add(string token, VehicleDTO dto);

        [OperationContract]
        bool Update(string token, VehicleDTO dto);

        [OperationContract]
        bool Remove(string token, int id);
    }
}
