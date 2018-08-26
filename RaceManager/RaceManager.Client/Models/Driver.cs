using RaceManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceManager.Client.Models
{
    class Driver : ObservableObject
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _umcn;

        public Driver() { }

        public int Id { get => _id; set => _id = value; }

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

        public string UMCN
        {
            get => _umcn; set
            {
                if (_umcn != value)
                {
                    _umcn = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
