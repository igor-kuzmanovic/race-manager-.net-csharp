using System;
using System.ServiceModel;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var loginService = new ServiceHost(typeof(LoginService));
            var userService = new ServiceHost(typeof(UserService));
            var raceService = new ServiceHost(typeof(RaceService));
            var driverService = new ServiceHost(typeof(DriverService));
            var vehicleService = new ServiceHost(typeof(VehicleService));

            loginService.Open();
            userService.Open();
            raceService.Open();
            driverService.Open();
            vehicleService.Open();

            Console.ReadKey();

            loginService.Close();
            userService.Close();
            raceService.Close();
            driverService.Close();
            vehicleService.Close();
        }
    }
}
