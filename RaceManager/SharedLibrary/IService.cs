using System.ServiceModel;

namespace SharedLibrary
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        void Ping();
    }
}
