using System;
using System.ServiceModel;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost service = new ServiceHost(typeof(TestService));
            service.Open();
            Console.ReadKey();
            service.Close();
        }
    }
}
