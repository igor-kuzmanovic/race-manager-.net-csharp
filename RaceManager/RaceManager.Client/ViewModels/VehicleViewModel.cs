using RaceManager.Client.Core;
using RaceManager.Client.DriverService;
using RaceManager.Client.Models;
using RaceManager.Client.DataMappers;
using RaceManager.Client.Models.Identity;
using RaceManager.Client.VehicleService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceManager.Client.ViewModels
{
    class VehicleViewModel : ObservableObject
    {
        #region Fields

        private readonly VehicleServiceClient _vehicleServiceClient;
        private readonly DriverServiceClient _driverServiceClient;
        private ObservableCollection<Vehicle> _vehicles;
        private ObservableCollection<Driver> _drivers;
        private Vehicle _selectedVehicle;
        private int _id;
        private string _manufacturer;
        private string _model;
        private string _type;
        private double _engineHorsepower;
        private double _engineDisplacement;
        private Driver _driver;

        #endregion

        public VehicleViewModel()
        {
            _vehicleServiceClient = new VehicleServiceClient();
            _driverServiceClient = new DriverServiceClient();
            LoadVehicles();
            RefreshCommand = new RelayCommand(OnRefresh);
            NewCommand = new RelayCommand(OnNew);
            EditCommand = new RelayCommand(OnEdit, CanEdit);
            CopyCommand = new RelayCommand(OnCopy, CanCopy);
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
            SaveCommand = new RelayCommand(OnSave, CanSave);
            OnNew();
        }

        #region Commands

        public RelayCommand RefreshCommand { get; }
        public RelayCommand NewCommand { get; }
        public RelayCommand EditCommand { get; }
        public RelayCommand CopyCommand { get; }
        public RelayCommand DeleteCommand { get; }
        public RelayCommand SaveCommand { get; }

        #endregion

        #region Properties

        public ObservableCollection<Vehicle> Vehicles
        {
            get => _vehicles; set
            {
                _vehicles = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Driver> Drivers
        {
            get => _drivers; set
            {
                _drivers = value;
                RaisePropertyChanged();
            }
        }

        public Vehicle SelectedVehicle
        {
            get => _selectedVehicle; set
            {
                _selectedVehicle = value;
                RaisePropertyChanged();
                EditCommand.RaiseCanExecuteChanged();
                CopyCommand.RaiseCanExecuteChanged();
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public int Id
        {
            get => _id; set
            {
                if (_id != value)
                {
                    _id = value;
                    RaisePropertyChanged();
                    SaveCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Manufacturer
        {
            get => _manufacturer; set
            {
                if (_manufacturer != value)
                {
                    _manufacturer = value;
                    RaisePropertyChanged();
                    SaveCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Model
        {
            get => _model; set
            {
                if (_model != value)
                {
                    _model = value;
                    RaisePropertyChanged();
                    SaveCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Type
        {
            get => _type; set
            {
                if (_type != value)
                {
                    _type = value;
                    RaisePropertyChanged();
                    SaveCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public double EngineHorsepower
        {
            get => _engineHorsepower; set
            {
                if (_engineHorsepower != value)
                {
                    _engineHorsepower = value;
                    RaisePropertyChanged();
                    SaveCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public double EngineDisplacement
        {
            get => _engineDisplacement; set
            {
                if (_engineDisplacement != value)
                {
                    _engineDisplacement = value;
                    RaisePropertyChanged();
                    SaveCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public Driver Driver
        {
            get => _driver; set
            {
                if (_driver != value)
                {
                    _driver = value;
                    RaisePropertyChanged();
                    SaveCommand.RaiseCanExecuteChanged();
                }
            }
        }

        #endregion Properties

        #region Helper Methods

        private void LoadVehicles()
        {
            var vehicles = VehicleMapper.Instance.Map(_vehicleServiceClient.GetAll(CurrentUser.Instance.SecurityToken)).ToList();
            var drivers = DriverMapper.Instance.Map(_driverServiceClient.GetAll(CurrentUser.Instance.SecurityToken)).ToList();

            vehicles.ForEach(v => v.Driver = drivers.SingleOrDefault(d => d.Id == v.Driver.Id));

            Vehicles = new ObservableCollection<Vehicle>(vehicles);
            Drivers = new ObservableCollection<Driver>(drivers);
        }

        #endregion

        #region Command Methods

        private void OnRefresh()
        {
            LoadVehicles();
        }

        private void OnNew()
        {
            Id = 0;
            Manufacturer = string.Empty;
            Model = string.Empty;
            Type = string.Empty;
            EngineHorsepower = 0;
            EngineDisplacement = 0;
            Driver = new Driver();
        }

        private void OnEdit()
        {
            Id = SelectedVehicle.Id;
            Manufacturer = SelectedVehicle.Manufacturer;
            Model = SelectedVehicle.Model;
            Type = SelectedVehicle.Type;
            EngineHorsepower = SelectedVehicle.EngineHorsepower;
            EngineDisplacement = SelectedVehicle.EngineDisplacement;
            Driver = SelectedVehicle.Driver;
        }

        private bool CanEdit()
        {
            return SelectedVehicle != null;
        }

        private void OnCopy()
        {
            Id = 0;
            Manufacturer = SelectedVehicle.Manufacturer;
            Model = SelectedVehicle.Model;
            Type = SelectedVehicle.Type;
            EngineHorsepower = SelectedVehicle.EngineHorsepower;
            EngineDisplacement = SelectedVehicle.EngineDisplacement;
            Driver = SelectedVehicle.Driver;
        }

        private bool CanCopy()
        {
            return SelectedVehicle != null;
        }

        private void OnDelete()
        {
            _vehicleServiceClient.Remove(CurrentUser.Instance.SecurityToken, SelectedVehicle.Id);
            LoadVehicles();
            OnNew();
        }

        private bool CanDelete()
        {
            return SelectedVehicle != null;
        }

        private void OnSave()
        {
            var vehicle = new Vehicle();
            vehicle.Id = Id > 0 ? Id : 0;
            vehicle.Manufacturer = Manufacturer;
            vehicle.Model = Model;
            vehicle.Type = Type;
            vehicle.EngineHorsepower = EngineHorsepower;
            vehicle.EngineDisplacement = EngineDisplacement;
            vehicle.Driver = Driver;

            if (Id > 0)
                _vehicleServiceClient.Update(CurrentUser.Instance.SecurityToken, VehicleMapper.Instance.Map(vehicle));
            else
                _vehicleServiceClient.Add(CurrentUser.Instance.SecurityToken, VehicleMapper.Instance.Map(vehicle));

            LoadVehicles();
            OnNew();
        }

        private bool CanSave()
        {
            return !string.IsNullOrWhiteSpace(Manufacturer)
                && !string.IsNullOrWhiteSpace(Model)
                && !string.IsNullOrWhiteSpace(Type)
                && EngineHorsepower > 0
                && EngineDisplacement > 0
                && Driver != null
                && Driver.Id > 0;
        }

        #endregion
    }
}