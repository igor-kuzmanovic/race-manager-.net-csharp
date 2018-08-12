using System;
using System.ServiceModel;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new ServiceHost(typeof(LoginService));
            service.Open();
            Console.ReadKey();
            service.Close();
        }
    }
}
