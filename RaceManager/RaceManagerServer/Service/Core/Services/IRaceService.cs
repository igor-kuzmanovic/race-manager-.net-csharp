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
    public interface IRaceService
    {
        [OperationContract]
        RaceDTO Get(int id);

        [OperationContract]
        IEnumerable<RaceDTO> GetAll();

        [OperationContract]
        void Add(RaceDTO dto);

        [OperationContract]
        void Update(RaceDTO dto);

        [OperationContract]
        void Remove(int id);
    }
}
