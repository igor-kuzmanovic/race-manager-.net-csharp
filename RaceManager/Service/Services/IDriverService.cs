using System.ServiceModel;

namespace Service
{
    [ServiceContract]
    public interface IDriverService : ICRUDService<DriverDTO>
    {
    }
}
