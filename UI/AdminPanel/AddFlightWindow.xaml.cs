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
using Controller;

namespace UI.AdminPanel
{
    /// <summary>
    /// Логика взаимодействия для AddFlightWindow.xaml
    /// </summary>
    public partial class AddFlightWindow : Window
    {
        public AddFlightWindow()
        {
            InitializeComponent();
        }

        private void AddFlight_Click(object sender, RoutedEventArgs e)
        {
            string departurepoint = Departure_TextBox.Text;
            string destinationpoint = Destination_Textbox.Text;
            string departuredate = Date_Textbox.Text;
            string departuretime = Time_TextBox.Text;
            string planeId = PlaneID_TextBox.Text;

            Administrator.AddFlight(departurepoint, destinationpoint, departuretime, departuredate, planeId);

            MessageBox.Show("Рейс добавлен");
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            new MainAdminMenu().Show();
            this.Close();
        }
    }
}
