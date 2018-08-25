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
