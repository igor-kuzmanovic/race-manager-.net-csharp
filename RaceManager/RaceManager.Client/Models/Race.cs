using RaceManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceManager.Client.Models
{
    class Race : ObservableObject
    {
        private int _id;
        private DateTime _eventDate;
        private string _eventLocation;

        public Race() { }

        public int Id { get => _id; set => _id = value; }

        public DateTime EventDate
        {
            get => _eventDate; set
            {
                if (_eventDate != value)
                {
                    _eventDate = value;
                    RaisePropertyChanged();
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
                }
            }
        }
    }
}
