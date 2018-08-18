using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Service
{
    [ServiceContract]
    public interface IRaceService : ICRUDService<RaceDTO>
    {
        [OperationContract]
        IEnumerable<RaceDTO> FindByEventDate(string securityToken, DateTime eventDate, DateTimeQueryType queryType);

        [OperationContract]
        IEnumerable<RaceDTO> FindByEventLocation(string securityToken, string eventLocation);
    }
}
