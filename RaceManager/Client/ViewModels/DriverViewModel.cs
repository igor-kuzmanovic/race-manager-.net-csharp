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
    class DriverViewModel : BindableBase
    {
        public MyICommand DeleteCommand { get; set; }

        public DriverViewModel()
        {
            LoadDrivers();
            DeleteCommand = new MyICommand(OnDelete, CanDelete);
        }

        public ObservableCollection<Driver> Drivers { get; set; }

        private void LoadDrivers()
        {
            ObservableCollection<Driver> drivers = new ObservableCollection<Driver>
            {
                new Driver()
                {
                    Manufacturer = "Test Manufacturer 1",
                    Model = "Test Model 1",
                    Type = "Test Type 1",
                    EngineHorsepower = 1,
                    EngineDisplacement = 1,
                    DriverId = 1
                },

                new Driver()
                {
                    Manufacturer = "Test Manufacturer 2",
                    Model = "Test Model 2",
                    Type = "Test Type 2",
                    EngineHorsepower = 2,
                    EngineDisplacement = 2,
                    DriverId = 2
                },

                new Driver()
                {
                    Manufacturer = "Test Manufacturer 3",
                    Model = "Test Model 3",
                    Type = "Test Type 3",
                    EngineHorsepower = 3,
                    EngineDisplacement = 3,
                    DriverId = 3
                }
            };

            Drivers = drivers;
        }

        private Driver selectedDriver;

        public Driver SelectedDriver
        {
            get => selectedDriver; set
            {
                selectedDriver = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        private bool CanDelete()
        {
            return SelectedDriver != null;
        }

        private void OnDelete()
        {
            Drivers.Remove(SelectedDriver);
        }
    }
}
