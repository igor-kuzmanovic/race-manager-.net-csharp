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
        private static ChannelFactory<ILoginService> factory = new ChannelFactory<ILoginService>("LoginService");
        private static ILoginService proxy = factory.CreateChannel();
        private static LoginDTO user;

        public MainWindow()
        {
            InitializeComponent();          
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            user = proxy.Login(TUsername.Text, TPassword.Text);
            MessageBox.Show("Logged in - Id: " + user.Id + ", Token: " + user.Token + ", Admin: " + user.IsAdmin);
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            proxy.Logout(user.Token);
            MessageBox.Show("Logged out");
        }
    }
}
