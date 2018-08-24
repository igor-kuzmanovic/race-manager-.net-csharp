using Client.Common;
using Client.Command;
using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            NavCommand = new MyICommand(OnNav);
        }

        private DriverViewModel driverViewModel = new DriverViewModel();

        private VehicleViewModel vehicleViewModel = new VehicleViewModel();

        private BindableBase currentViewModel;

        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set { SetProperty(ref currentViewModel, value); }
        }

        public MyICommand NavCommand { get; private set; }

        private void OnNav()
        {
            string destination = string.Empty;
            switch (destination)
            {
                case "drivers":
                    CurrentViewModel = driverViewModel;
                    break;
                case "vehicles":
                default:
                    CurrentViewModel = vehicleViewModel;
                    break;
            }
        }
    }
}
