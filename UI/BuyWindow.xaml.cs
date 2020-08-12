using Controller;
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
    /// Логика взаимодействия для BuyWindow.xaml
    /// </summary>
    public partial class BuyWindow : Window
    {
        string CurrentFlightId { get; }
        static string[] accountInfo;
        static string[] flightInfo;
        
        
        public BuyWindow(string[] userInfo, string flightId)
        {
            CurrentFlightId = flightId;
            InitializeComponent();
            FlightIdLabel.Content = flightId;
            accountInfo = userInfo;
            flightInfo = new FlightControlPanel().SearchFlight(Convert.ToInt32(flightId));


            DestinationLabel.Content = flightInfo[1] + " => " + flightInfo[2];
            DateTimeLable.Content = flightInfo[3];
            PlaneIdLabel.Content = flightInfo[4];

            AccountNameLabel.Content = accountInfo[1];
            AccountLastNameLabel.Content = accountInfo[2];
            AccountNumberLabel.Content = accountInfo[4];

        }

        
        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
           
           FlightControlPanel.SaveTicket(flightInfo[0],accountInfo[4], flightInfo[1], flightInfo[2], flightInfo[3]);
            MessageBox.Show("Спасибо за покупку!");
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

            new FlightCatalog(accountInfo).Show();
            this.Close();
        }
    }
}
