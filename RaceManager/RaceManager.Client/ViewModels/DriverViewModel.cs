using RaceManager.Client.DriverService;
using RaceManager.Client.Models;
using RaceManager.Client.Models.Converters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceManager.Client.ViewModels
{
    class DriverViewModel
    {
        private readonly DriverServiceClient _driverServiceClient;

        public DriverViewModel()
        {
            _driverServiceClient = new DriverServiceClient();
            LoadDrivers();
        }

        public ObservableCollection<Driver> Drivers { get; set; }

        private void LoadDrivers()
        {
            //Drivers = new ObservableCollection<Driver>(DriverConverter.Instance.Convert(_driverServiceClient.GetAll()));

            var drivers = new List<Driver>()
            {
                new Driver()
                {
                    Id = 0,
                    FirstName = "John 1",
                    LastName = "Doe 1",
                    UMCN = "1111111111111"
                },
                new Driver()
                {
                    Id = 1,
                    FirstName = "John 2",
                    LastName = "Doe 2",
                    UMCN = "2222222222222"
                },
                new Driver()
                {
                    Id = 2,
                    FirstName = "John 3",
                    LastName = "Doe 3",
                    UMCN = "3333333333333"
                }
            };

            Drivers = new ObservableCollection<Driver>(drivers);
        }
    }
}
