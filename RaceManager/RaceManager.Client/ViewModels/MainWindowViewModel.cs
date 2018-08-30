using RaceManager.Client.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceManager.Client.ViewModels
{
    class MainWindowViewModel : ObservableObject
    {
        #region Fields

        private bool _isRaceViewVisible;
        private bool _isDriverViewVisible;
        private bool _isVehicleViewVisible;
        private bool _isUserViewVisible;
        private bool _isLogInViewVisible;
        private bool _isLogOutViewVisible;
        private bool _isSettingsViewVisible;

        #endregion

        public MainWindowViewModel()
        {
            InitializeViewVisibility();
        }

        #region Commands



        #endregion

        #region Properties

        public bool IsRaceViewVisible
        {
            get => _isRaceViewVisible; set
            {
                _isRaceViewVisible = value;
                RaisePropertyChanged();
            }
        }

        public bool IsDriverViewVisible
        {
            get => _isDriverViewVisible; set
            {
                _isDriverViewVisible = value;
                RaisePropertyChanged();
            }
        }

        public bool IsVehicleViewVisible
        {
            get => _isVehicleViewVisible; set
            {
                _isVehicleViewVisible = value;
                RaisePropertyChanged();
            }
        }

        public bool IsUserViewVisible
        {
            get => _isUserViewVisible; set
            {
                _isUserViewVisible = value;
                RaisePropertyChanged();
            }
        }

        public bool IsLogInViewVisible
        {
            get => _isLogInViewVisible; set
            {
                _isLogInViewVisible = value;
                RaisePropertyChanged();
            }
        }

        public bool IsLogOutViewVisible
        {
            get => _isLogOutViewVisible; set
            {
                _isLogOutViewVisible = value;
                RaisePropertyChanged();
            }
        }

        public bool IsSettingsViewVisible
        {
            get => _isSettingsViewVisible; set
            {
                _isSettingsViewVisible = value;
                RaisePropertyChanged();
            }
        }

        #endregion Properties

        #region Helper Methods

        private void InitializeViewVisibility()
        {
            IsRaceViewVisible = false;
            IsDriverViewVisible = false;
            IsVehicleViewVisible = false;
            IsUserViewVisible = false;
            IsLogInViewVisible = true;
            IsLogOutViewVisible = false;
            IsSettingsViewVisible = false;
        }

        #endregion

        #region Command Methods



        #endregion
    }
}
