using System.ServiceModel;

namespace Service
{
    [ServiceContract]
    public interface IUserService : ICRUDService<UserDTO>
    {
    }
}
