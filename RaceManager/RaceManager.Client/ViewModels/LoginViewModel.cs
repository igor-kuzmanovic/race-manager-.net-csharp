using RaceManager.Client.Core;
using RaceManager.Client.Models;
using RaceManager.Client.Models.Converters;
using RaceManager.Client.VehicleService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RaceManager.Client.ViewModels
{
    class LogInViewModel : ObservableObject
    {
        #region Fields

        private string _username;
        private string _password;

        #endregion

        public LogInViewModel()
        {
            LogInCommand = new RelayCommand(OnLogIn, CanLogIn);
        }

        #region Commands

        public RelayCommand LogInCommand { get; }

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

        #endregion Properties

        #region Helper Methods



        #endregion

        #region Command Methods

        private void OnLogIn()
        {
            MessageBox.Show(Username + "_" + Password);
        }

        private bool CanLogIn()
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }

        #endregion
    }
}