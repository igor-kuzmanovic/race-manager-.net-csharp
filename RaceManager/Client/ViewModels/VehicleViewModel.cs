using Client.Binding;
using Client.Command;
using Client.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    class VehicleViewModel : BindableBase
    {
        public MyICommand DeleteCommand { get; set; }

        public VehicleViewModel()
        {
            LoadVehicles();
            DeleteCommand = new MyICommand(OnDelete, CanDelete);
        }

        public ObservableCollection<Vehicle> Vehicles { get; set; }

        private void LoadVehicles()
        {
            ObservableCollection<Vehicle> vehicles = new ObservableCollection<Vehicle>
            {
                new Vehicle()
                {
                    Manufacturer = "Test Manufacturer 1",
                    Model = "Test Model 1",
                    Type = "Test Type 1",
                    EngineHorsepower = 1,
                    EngineDisplacement = 1,
                    DriverId = 1
                },

                new Vehicle()
                {
                    Manufacturer = "Test Manufacturer 2",
                    Model = "Test Model 2",
                    Type = "Test Type 2",
                    EngineHorsepower = 2,
                    EngineDisplacement = 2,
                    DriverId = 2
                },

                new Vehicle()
                {
                    Manufacturer = "Test Manufacturer 3",
                    Model = "Test Model 3",
                    Type = "Test Type 3",
                    EngineHorsepower = 3,
                    EngineDisplacement = 3,
                    DriverId = 3
                }
            };

            Vehicles = vehicles;
        }

        private Vehicle selectedVehicle;

        public Vehicle SelectedVehicle
        {
            get => selectedVehicle; set
            {
                selectedVehicle = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        private void OnDelete()
        {
            Vehicles.Remove(SelectedVehicle);
        }

        private bool CanDelete()
        {
            return SelectedVehicle != null;
        }
    }
}
