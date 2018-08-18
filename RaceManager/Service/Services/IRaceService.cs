using System.ServiceModel;

namespace Service
{
    [ServiceContract]
    public interface IRaceService : ICRUDService<RaceDTO>
    {
    }
}
