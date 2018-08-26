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
            //Vehicles = new ObservableCollection<Vehicle>(VehicleConverter.Instance.Convert(_vehicleServiceClient.GetAll()));

            var vehicles = new List<Vehicle>()
            {
                new Vehicle()
                {
                    Id = 0,
                    Manufacturer = "Manufacturer 1",
                    Model = "Model 1",
                    Type = "Type 1",
                    EngineHorsepower = 111,
                    EngineDisplacement = 1
                },
                new Vehicle()
                {
                    Id = 1,
                    Manufacturer = "Manufacturer 2",
                    Model = "Model 2",
                    Type = "Type 2",
                    EngineHorsepower = 222,
                    EngineDisplacement = 2
                },
                new Vehicle()
                {
                    Id = 2,
                    Manufacturer = "Manufacturer 3",
                    Model = "Model 3",
                    Type = "Type 3",
                    EngineHorsepower = 333,
                    EngineDisplacement = 3
                },
            };

            Vehicles = new ObservableCollection<Vehicle>(vehicles);
        }
    }
}
