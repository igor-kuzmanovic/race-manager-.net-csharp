using Service;

namespace Server
{
    class TestService : ITestService
    {
        public string Test()
        {
            return "Test service success!";
        }
    }
}
