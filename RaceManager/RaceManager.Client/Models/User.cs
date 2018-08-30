using RaceManager.Client.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceManager.Client.Models
{
    class User : ObservableObject
    {
        private int _id;
        private string _username;
        private string _password;
        private string _firstName;
        private string _lastName;
        private string _securityToken;
        private bool _isAdmin;

        public User() { }

        public int Id
        {
            get => _id; set
            {
                if (_id != value)
                {
                    _id = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string Username
        {
            get => _username; set
            {
                if (_username != value)
                {
                    _username = value;
                    RaisePropertyChanged();
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
                }
            }
        }

        public string SecurityToken
        {
            get => _securityToken; set
            {
                if (_securityToken != value)
                {
                    _securityToken = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool IsAdmin
        {
            get => _isAdmin; set
            {
                if (_isAdmin != value)
                {
                    _isAdmin = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
