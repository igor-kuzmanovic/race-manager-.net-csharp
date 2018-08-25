using RaceManagerServer.Service.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RaceManagerServer.Service.Core.Services
{
    [ServiceContract]
    public interface IVehicleService
    {
        [OperationContract]
        VehicleDTO Get(int id);

        [OperationContract]
        IEnumerable<VehicleDTO> GetAll();

        [OperationContract]
        void Add(VehicleDTO dto);

        [OperationContract]
        void Update(VehicleDTO dto);

        [OperationContract]
        void Remove(int id);
    }
}
