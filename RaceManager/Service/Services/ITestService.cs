using System.ServiceModel;

namespace Service
{
    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        string Test();
    }
}
