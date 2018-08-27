using RaceManager.Client.Core;
using RaceManager.Client.DriverService;
using RaceManager.Client.Models;
using RaceManager.Client.Models.Converters;
using RaceManager.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceManager.Client.ViewModels
{
    class DriverViewModel : ObservableObject
    {
        private readonly DriverServiceClient _driverServiceClient;
        private ObservableCollection<Driver> _drivers;
        private Driver _selectedDriver;
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _umcn;

        public DriverViewModel()
        {
            _driverServiceClient = new DriverServiceClient();
            NewCommand = new RelayCommand(OnNew);
            EditCommand = new RelayCommand(OnEdit, CanEdit);
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
            SaveCommand = new RelayCommand(OnSave, CanSave); 
            LoadDrivers();
        }

        public RelayCommand NewCommand { get; }
        public RelayCommand EditCommand { get; }
        public RelayCommand DeleteCommand { get; }
        public RelayCommand SaveCommand { get; }

        public ObservableCollection<Driver> Drivers
        {
            get => _drivers; set
            {
                _drivers = value;
                RaisePropertyChanged();
            }
        }

        public Driver SelectedDriver
        {
            get => _selectedDriver; set
            {
                _selectedDriver = value;
                RaisePropertyChanged();
                EditCommand.RaiseCanExecuteChanged();
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

        public string FirstName
        {
            get => _firstName; set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    RaisePropertyChanged();
                    SaveCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string LastName
        {
            get => _lastName; set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    RaisePropertyChanged();
                    SaveCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string UMCN
        {
            get => _umcn; set
            {
                if (_umcn != value)
                {
                    _umcn = value;
                    RaisePropertyChanged();
                    SaveCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private void LoadDrivers()
        {
            //Drivers = new ObservableCollection<Driver>(DriverConverter.Instance.Convert(_driverServiceClient.GetAll()));

            var drivers = new List<Driver>()
            {
                new Driver()
                {
                    Id = 1,
                    FirstName = "John 1",
                    LastName = "Doe 1",
                    UMCN = "1111111111111"
                },
                new Driver()
                {
                    Id = 2,
                    FirstName = "John 2",
                    LastName = "Doe 2",
                    UMCN = "2222222222222"
                },
                new Driver()
                {
                    Id = 3,
                    FirstName = "John 3",
                    LastName = "Doe 3",
                    UMCN = "3333333333333"
                }
            };

            Drivers = new ObservableCollection<Driver>(drivers);
        }

        private void OnNew()
        {
            Id = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
            UMCN = string.Empty;
        }

        private void OnEdit()
        {
            Id = SelectedDriver.Id;
            FirstName = SelectedDriver.FirstName;
            LastName = SelectedDriver.LastName;
            UMCN = SelectedDriver.UMCN;
        }

        private bool CanEdit()
        {
            return SelectedDriver != null;
        }

        private void OnDelete()
        {
            //_driverServiceClient.Remove(SelectedDriver.Id);

            Drivers.Remove(SelectedDriver);

            if (Id == SelectedDriver.Id)
                OnNew();
        }

        private bool CanDelete()
        {
            return SelectedDriver != null;
        }

        private void OnSave()
        {
            var driver = new Driver();
            driver.FirstName = FirstName;
            driver.LastName = LastName;
            driver.UMCN = UMCN;

            if (Id > 0)
            {
                driver.Id = Id;

                //_driverServiceClient.Update(DriverConverter.Instance.Convert(driver));

                SelectedDriver.FirstName = FirstName;
                SelectedDriver.LastName = LastName;
                SelectedDriver.UMCN = UMCN;
            }
            else
            {
                //_driverServiceClient.Add(DriverConverter.Instance.Convert(driver));

                Drivers.Add(driver);
            }

            OnNew();
        }

        private bool CanSave()
        {
            return !string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName) && !string.IsNullOrWhiteSpace(UMCN);
        }
    }
}
