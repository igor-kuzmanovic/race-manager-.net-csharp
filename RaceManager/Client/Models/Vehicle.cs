using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    class Vehicle : INotifyPropertyChanged
    {
        private string manufacturer;
        private string model;
        private string type;
        private double engineHorsepower;
        private double engineDisplacement;
        private int driverId;

        public string Manufacturer
        {
            get => manufacturer; set
            {
                if (manufacturer != value)
                {
                    manufacturer = value;
                    RaisePropertyChanged("Manufacturer");
                    RaisePropertyChanged("Print");
                }
            }
        }

        public string Model
        {
            get => model; set
            {
                if (model != value)
                {
                    model = value;
                    RaisePropertyChanged("Model");
                    RaisePropertyChanged("Print");
                }
            }
        }
        public string Type
        {
            get => type; set
            {
                if (type != value)
                {
                    type = value;
                    RaisePropertyChanged("Type");
                    RaisePropertyChanged("Print");
                }
            }
        }

        public double EngineHorsepower
        {
            get => engineHorsepower; set
            {
                if (engineHorsepower != value)
                {
                    engineHorsepower = value;
                    RaisePropertyChanged("EngineHorsepower");
                    RaisePropertyChanged("Print");
                }
            }
        }

        public double EngineDisplacement
        {
            get => engineDisplacement; set
            {
                if (engineDisplacement != value)
                {
                    engineDisplacement = value;
                    RaisePropertyChanged("EngineDisplacement");
                    RaisePropertyChanged("Print");
                }
            }
        }

        public int DriverId
        {
            get => driverId; set
            {
                if (driverId != value)
                {
                    driverId = value;
                    RaisePropertyChanged("DriverId");
                    RaisePropertyChanged("Print");
                }
            }
        }

        public string Print
        {
            get => "Vehicle: " + manufacturer + "_" + model + "_" + type + "_" + engineHorsepower + "_" + engineDisplacement + "_" + driverId;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
