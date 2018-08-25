using RaceManager.Client.Models;
using RaceManager.Client.Models.Converters;
using RaceManager.Client.VehicleService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceManager.Client.ViewModels
{
    class VehicleViewModel
    {
        private readonly VehicleServiceClient _vehicleServiceClient;

        public VehicleViewModel()
        {
            _vehicleServiceClient = new VehicleServiceClient();
            LoadVehicles();
        }

        public ObservableCollection<Vehicle> Vehicles { get; set; }

        private void LoadVehicles()
        {
            Vehicles = new ObservableCollection<Vehicle>(VehicleConverter.Instance.Convert(_vehicleServiceClient.GetAll()));
        }
    }
}
