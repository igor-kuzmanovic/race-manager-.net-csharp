using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static ChannelFactory<ILoginService> loginFactory = new ChannelFactory<ILoginService>("LoginService");
        private static ILoginService loginProxy = loginFactory.CreateChannel();

        private static ChannelFactory<IUserService> userFactory = new ChannelFactory<IUserService>("UserService");
        private static IUserService userProxy = userFactory.CreateChannel();

        private static ChannelFactory<IRaceService> raceFactory = new ChannelFactory<IRaceService>("RaceService");
        private static IRaceService raceProxy = raceFactory.CreateChannel();

        private static ChannelFactory<IDriverService> driverFactory = new ChannelFactory<IDriverService>("DriverService");
        private static IDriverService driverProxy = driverFactory.CreateChannel();

        private static ChannelFactory<IVehicleService> vehicleFactory = new ChannelFactory<IVehicleService>("VehicleService");
        private static IVehicleService vehicleProxy = vehicleFactory.CreateChannel();

        private static UserDTO user;

        public MainWindow()
        {
            InitializeComponent();          
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            user = loginProxy.Login(TUsername.Text, TPassword.Text);
            MessageBox.Show("Logged in - Id: " + user.Id + ", Token: " + user.Token + ", Admin: " + user.IsAdmin);
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            loginProxy.Logout(user.Token);
            MessageBox.Show("Logged out");
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
