using RaceManager.Client.Core;
using RaceManager.Client.Models;
using RaceManager.Client.Models.DataMappers;
using RaceManager.Client.RaceService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RaceManager.Client.ViewModels
{
    class RaceViewModel : ObservableObject
    {
        #region Fields

        private readonly RaceServiceClient _raceServiceClient;
        private ObservableCollection<Race> _races;
        private Race _selectedRace;
        private int _id;
        private DateTime _eventDate;
        private string _eventLocation;

        #endregion

        public RaceViewModel()
        {
            _raceServiceClient = new RaceServiceClient();
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

        public ObservableCollection<Race> Races
        {
            get => _races; set
            {
                _races = value;
                RaisePropertyChanged();
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
            Races = new ObservableCollection<Race>(RaceMapper.Instance.Map(_raceServiceClient.GetAll()));
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
        }

        private void OnEdit()
        {
            Id = SelectedRace.Id;
            EventDate = SelectedRace.EventDate;
            EventLocation = SelectedRace.EventLocation;
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
        }

        private bool CanCopy()
        {
            return SelectedRace != null;
        }

        private void OnDelete()
        {
            _raceServiceClient.Remove(SelectedRace.Id);
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

            if (Id > 0)
                _raceServiceClient.Update(RaceMapper.Instance.Map(race));
            else
                _raceServiceClient.Add(RaceMapper.Instance.Map(race));

            LoadRaces();
            OnNew();
        }

        private bool CanSave()
        {
            return EventDate != null && !string.IsNullOrWhiteSpace(EventLocation);
        }

        #endregion
    }
}