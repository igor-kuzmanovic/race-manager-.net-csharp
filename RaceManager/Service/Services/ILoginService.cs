using System.ServiceModel;

namespace Service
{
    [ServiceContract]
    public interface ILoginService
    {
        [OperationContract]
        LoginDTO Login(string username, string password);

        [OperationContract]
        void Logout(string token);
    }
}
