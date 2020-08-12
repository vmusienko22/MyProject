using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Логика взаимодействия для MainUserMenu.xaml
    /// </summary>
    public partial class MainUserMenu : Window
    {
        private string[] accountInfo;
        public MainUserMenu(string[] accountInfo)
        {
            InitializeComponent();
            this.accountInfo = accountInfo;
        }

        private void PersonalDataButton_Click(object sender, RoutedEventArgs e)
        {
            
            new UserPersonalData(accountInfo).Show();
            this.Close();
        }

        private void FindFlightButton_Click(object sender, RoutedEventArgs e)
        {
            
            new FlightCatalog(accountInfo).Show();
            this.Close();
        }
    }
}
