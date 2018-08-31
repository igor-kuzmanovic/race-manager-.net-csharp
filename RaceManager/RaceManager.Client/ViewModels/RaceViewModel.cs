using RaceManager.Client.Core;
using RaceManager.Client.DriverService;
using RaceManager.Client.Models;
using RaceManager.Client.DataMappers;
using RaceManager.Client.Models.Identity;
using RaceManager.Client.RaceService;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace RaceManager.Client.ViewModels
{
    class RaceViewModel : ObservableObject
    {
        #region Fields

        private readonly RaceServiceClient _raceServiceClient;
        private readonly DriverServiceClient _driverServiceClient;
        private ObservableCollection<Race> _races;
        private ObservableCollection<Driver> _drivers;
        private ObservableCollection<Driver> _availableDrivers;
        private ObservableCollection<Driver> _selectedDrivers;
        private Driver _driverToRemove;
        private Driver _driverToAdd;
        private Race _selectedRace;
        private int _id;
        private DateTime _eventDate;
        private string _eventLocation;

        #endregion

        public RaceViewModel()
        {
            _raceServiceClient = new RaceServiceClient();
            _driverServiceClient = new DriverServiceClient();
            LoadRaces();
            RefreshCommand = new RelayCommand(OnRefresh);
            NewCommand = new RelayCommand(OnNew);
            EditCommand = new RelayCommand(OnEdit, CanEdit);
            CopyCommand = new RelayCommand(OnCopy, CanCopy);
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
            SaveCommand = new RelayCommand(OnSave, CanSave);
            AddDriverCommand = new RelayCommand(OnAddDriver, CanAddDriver);
            RemoveDriverCommand = new RelayCommand(OnRemoveDriver, CanRemoveDriver);
            OnNew();
        }

        #region Commands

        public RelayCommand RefreshCommand { get; }
        public RelayCommand NewCommand { get; }
        public RelayCommand EditCommand { get; }
        public RelayCommand CopyCommand { get; }
        public RelayCommand DeleteCommand { get; }
        public RelayCommand SaveCommand { get; }
        public RelayCommand AddDriverCommand { get; }
        public RelayCommand RemoveDriverCommand { get; }

        #endregion

        #region Properties

        public ObservableCollection<Race> Races
        {
            get => _races; set
            {
                _races = value;
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

        public ObservableCollection<Driver> AvailableDrivers
        {
            get => _availableDrivers; set
            {
                _availableDrivers = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Driver> SelectedDrivers
        {
            get => _selectedDrivers; set
            {
                _selectedDrivers = value;
                RaisePropertyChanged();
            }
        }

        public Driver DriverToAdd
        {
            get => _driverToAdd; set
            {
                _driverToAdd = value;
                RaisePropertyChanged();
                AddDriverCommand.RaiseCanExecuteChanged();
            }
        }

        public Driver DriverToRemove
        {
            get => _driverToRemove; set
            {
                _driverToRemove = value;
                RaisePropertyChanged();
                RemoveDriverCommand.RaiseCanExecuteChanged();
            }
        }

        public Race SelectedRace
        {
            get => _selectedRace; set
            {
                _selectedRace = value;
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

        public DateTime EventDate
        {
            get => _eventDate; set
            {
                if (_eventDate != value)
                {
                    _eventDate = value;
                    RaisePropertyChanged();
                    SaveCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string EventLocation
        {
            get => _eventLocation; set
            {
                if (_eventLocation != value)
                {
                    _eventLocation = value;
                    RaisePropertyChanged();
                    SaveCommand.RaiseCanExecuteChanged();
                }
            }
        }

        #endregion Properties

        #region Helper Methods

        private void LoadRaces()
        {
            var races = RaceMapper.Instance.Map(_raceServiceClient.GetAll(CurrentUser.Instance.SecurityToken)).ToList();
            var drivers = DriverMapper.Instance.Map(_driverServiceClient.GetAll(CurrentUser.Instance.SecurityToken)).ToList();

            foreach (var race in races)
                foreach (var driver in race.Drivers)
                {
                    var tempDriver = drivers.SingleOrDefault(d => d.Id == driver.Id);
                    driver.FirstName = tempDriver.FirstName;
                    driver.LastName = tempDriver.LastName;
                    driver.UMCN = tempDriver.UMCN;
                }

            Races = new ObservableCollection<Race>(races);
            Drivers = new ObservableCollection<Driver>(drivers);
        }

        #endregion

        #region Command Methods

        private void OnRefresh()
        {
            LoadRaces();
        }

        private void OnNew()
        {
            Id = 0;
            EventDate = DateTime.Now;
            EventLocation = string.Empty;
            SelectedDrivers = new ObservableCollection<Driver>();
            AvailableDrivers = new ObservableCollection<Driver>(Drivers);
        }

        private void OnEdit()
        {
            Id = SelectedRace.Id;
            EventDate = SelectedRace.EventDate;
            EventLocation = SelectedRace.EventLocation;
            SelectedDrivers = new ObservableCollection<Driver>(SelectedRace.Drivers);
            AvailableDrivers = new ObservableCollection<Driver>(Drivers.Where(d => !SelectedDrivers.Any(sd => d.Id == sd.Id)));
        }

        private bool CanEdit()
        {
            return SelectedRace != null;
        }

        private void OnCopy()
        {
            Id = 0;
            EventDate = SelectedRace.EventDate;
            EventLocation = SelectedRace.EventLocation;
            SelectedDrivers = new ObservableCollection<Driver>(SelectedRace.Drivers);
            AvailableDrivers = new ObservableCollection<Driver>(Drivers.Where(d => !SelectedDrivers.Any(sd => d.Id == sd.Id)));
        }

        private bool CanCopy()
        {
            return SelectedRace != null;
        }

        private void OnDelete()
        {
            _raceServiceClient.Remove(CurrentUser.Instance.SecurityToken, SelectedRace.Id);
            LoadRaces();
            OnNew();
        }

        private bool CanDelete()
        {
            return SelectedRace != null;
        }

        private void OnSave()
        {
            var race = new Race();
            race.Id = Id > 0 ? Id : 0;
            race.EventDate = EventDate;
            race.EventLocation = EventLocation;
            race.Drivers = SelectedDrivers;

            if (Id > 0)
                _raceServiceClient.Update(CurrentUser.Instance.SecurityToken, RaceMapper.Instance.Map(race));
            else
                _raceServiceClient.Add(CurrentUser.Instance.SecurityToken, RaceMapper.Instance.Map(race));

            LoadRaces();
            OnNew();
        }

        private bool CanSave()
        {
            return EventDate != null 
                && !string.IsNullOrWhiteSpace(EventLocation);
        }

        private void OnAddDriver()
        {
            SelectedDrivers.Add(DriverToAdd);
            AvailableDrivers.Remove(DriverToAdd);
        }

        private bool CanAddDriver()
        {
            return DriverToAdd != null;
        }

        private void OnRemoveDriver()
        {
            AvailableDrivers.Add(DriverToAdd);
            SelectedDrivers.Remove(DriverToRemove);
        }

        private bool CanRemoveDriver()
        {
            return DriverToRemove != null;
        }

        #endregion
    }
}