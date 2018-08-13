using System.ServiceModel;

namespace Service
{
    [ServiceContract]
    public interface ILoginService
    {
        [OperationContract]
        UserDTO Login(string username, string password);

        [OperationContract]
        void Logout(string token);
    }
}
