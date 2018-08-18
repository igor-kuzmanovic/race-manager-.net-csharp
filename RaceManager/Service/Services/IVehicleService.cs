using System.ServiceModel;

namespace Service
{
    [ServiceContract]
    public interface IVehicleService : ICRUDService<VehicleDTO>
    {
    }
}
