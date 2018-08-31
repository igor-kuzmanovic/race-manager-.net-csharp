using RaceManager.Client.Core;
using RaceManager.Client.LoginService;
using RaceManager.Client.Models;
using RaceManager.Client.DataMappers;
using RaceManager.Client.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RaceManager.Client.ViewModels
{
    class MainWindowViewModel : ObservableObject
    {
        #region Fields

        private readonly LoginServiceClient _loginServiceClient;
        private string _username;
        private string _password;
        private bool _isRaceViewEnabled;
        private bool _isDriverViewEnabled;
        private bool _isVehicleViewEnabled;
        private bool _isUserViewEnabled;
        private bool _isLogInViewEnabled;
        private bool _isLogOutViewEnabled;
        private bool _isRaceViewSelected;
        private bool _isLogInViewSelected;

        #endregion

        public MainWindowViewModel()
        {
            _loginServiceClient = new LoginServiceClient();
            DisableViewsWhenLoggedOut();
            LogInCommand = new RelayCommand(OnLogIn, CanLogIn);
            LogOutCommand = new RelayCommand(OnLogOut);
        }

        #region Commands

        public RelayCommand LogInCommand { get; }
        public RelayCommand LogOutCommand { get; }

        #endregion

        #region Properties

        public string Username
        {
            get => _username; set
            {
                if (_username != value)
                {
                    _username = value;
                    RaisePropertyChanged();
                    LogInCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Password
        {
            get => _password; set
            {
                if (_password != value)
                {
                    _password = value;
                    RaisePropertyChanged();
                    LogInCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public bool IsRaceViewEnabled
        {
            get => _isRaceViewEnabled; set
            {
                if (_isRaceViewEnabled != value)
                {
                    _isRaceViewEnabled = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool IsDriverViewEnabled
        {
            get => _isDriverViewEnabled; set
            {
                if (_isDriverViewEnabled != value)
                {
                    _isDriverViewEnabled = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool IsVehicleViewEnabled
        {
            get => _isVehicleViewEnabled; set
            {
                if (_isVehicleViewEnabled != value)
                {
                    _isVehicleViewEnabled = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool IsUserViewEnabled
        {
            get => _isUserViewEnabled; set
            {
                if (_isUserViewEnabled != value)
                {
                    _isUserViewEnabled = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool IsLogInViewEnabled
        {
            get => _isLogInViewEnabled; set
            {
                if (_isLogInViewEnabled != value)
                {
                    _isLogInViewEnabled = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool IsLogOutViewEnabled
        {
            get => _isLogOutViewEnabled; set
            {
                if (_isLogOutViewEnabled != value)
                {
                    _isLogOutViewEnabled = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool IsRaceViewSelected
        {
            get => _isRaceViewSelected; set
            {
                if (_isRaceViewSelected != value)
                {
                    _isRaceViewSelected = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool IsLogInViewSelected
        {
            get => _isLogInViewSelected; set
            {
                if (_isLogInViewSelected != value)
                {
                    _isLogInViewSelected = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion Properties

        #region Helper Methods

        private void EnableViewsWhenLoggedIn()
        {
            IsRaceViewEnabled = true;
            IsDriverViewEnabled = true;
            IsVehicleViewEnabled = true;
            IsUserViewEnabled = true;
            IsLogInViewEnabled = false;
            IsLogOutViewEnabled = true;

            IsRaceViewSelected = true;
            IsLogInViewSelected = false;
        }

        private void DisableViewsWhenLoggedOut()
        {
            IsRaceViewEnabled = false;
            IsDriverViewEnabled = false;
            IsVehicleViewEnabled = false;
            IsUserViewEnabled = false;
            IsLogInViewEnabled = true;
            IsLogOutViewEnabled = false;

            IsRaceViewSelected = false;
            IsLogInViewSelected = true;
        }

        private void ClearForm()
        {
            Username = string.Empty;
            Password = string.Empty;
        }

        #endregion

        #region Command Methods

        private void OnLogIn()
        {
            var user = LoginMapper.Instance.Map(_loginServiceClient.LogIn(Username, Password));

            if (string.IsNullOrWhiteSpace(user.SecurityToken))
            {
                MessageBox.Show("An error occured, please try again!");
            }
            else
            {
                CurrentUser.LoadUser(user);
                EnableViewsWhenLoggedIn();
                ClearForm();
            }
        }

        private bool CanLogIn()
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }

        private void OnLogOut()
        {
            _loginServiceClient.LogOut(CurrentUser.Instance.SecurityToken);
            CurrentUser.UnloadUser();
            DisableViewsWhenLoggedOut();
        }

        #endregion
    }
}
