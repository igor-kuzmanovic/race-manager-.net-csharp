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
            Drivers = new ObservableCollection<Driver>(DriverConverter.Instance.Convert(_driverServiceClient.GetAll()));
        }
    }
}
