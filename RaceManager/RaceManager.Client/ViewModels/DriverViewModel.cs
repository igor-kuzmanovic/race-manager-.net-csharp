using RaceManager.Client.Core;
using RaceManager.Client.DriverService;
using RaceManager.Client.Models;
using RaceManager.Client.Models.DataMappers;
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
        #region Fields

        private readonly DriverServiceClient _driverServiceClient;
        private ObservableCollection<Driver> _drivers;
        private Driver _selectedDriver;
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _umcn;

        #endregion

        public DriverViewModel()
        {
            _driverServiceClient = new DriverServiceClient();
            RefreshCommand = new RelayCommand(OnRefresh);
            NewCommand = new RelayCommand(OnNew);
            EditCommand = new RelayCommand(OnEdit, CanEdit);
            CopyCommand = new RelayCommand(OnCopy, CanCopy);
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
            SaveCommand = new RelayCommand(OnSave, CanSave); 
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

        #endregion

        #region Helper Methods

        private void LoadDrivers()
        {
            Drivers = new ObservableCollection<Driver>(DriverMapper.Instance.Map(_driverServiceClient.GetAll()));
        }

        #endregion

        #region Command Methods

        private void OnRefresh()
        {
            LoadDrivers();
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

        private void OnCopy()
        {
            Id = 0;
            FirstName = SelectedDriver.FirstName;
            LastName = SelectedDriver.LastName;
            UMCN = SelectedDriver.UMCN;
        }

        private bool CanCopy()
        {
            return SelectedDriver != null;
        }

        private void OnDelete()
        {
            _driverServiceClient.Remove(SelectedDriver.Id);
            LoadDrivers();
            OnNew();
        }

        private bool CanDelete()
        {
            return SelectedDriver != null;
        }

        private void OnSave()
        {
            var driver = new Driver();
            driver.Id = Id > 0 ? Id : 0;
            driver.FirstName = FirstName;
            driver.LastName = LastName;
            driver.UMCN = UMCN;

            if (Id > 0)
                _driverServiceClient.Update(DriverMapper.Instance.Map(driver));
            else
                _driverServiceClient.Add(DriverMapper.Instance.Map(driver));
                
            LoadDrivers();
            OnNew();
        }

        private bool CanSave()
        {
            return !string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName) && !string.IsNullOrWhiteSpace(UMCN);
        }

        #endregion
    }
}