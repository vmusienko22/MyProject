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
    /// Логика взаимодействия для FlightCatalog.xaml
    /// </summary>
    public partial class FlightCatalog : Window
    {
        private string[] userInfo;
        List<string> avalibleFlights;
        string[,] result;
        public FlightCatalog(string[] userInfo)
        {
            this.userInfo = userInfo;
            InitializeComponent();

            string[] flights = {"Киев","Львов","Варшава","Токио"};
            List<string> sorted = flights.ToList();
            sorted.Sort();


            foreach (var item in sorted)
            {
                FlightFromComboBox.Items.Add(item);
                FlightToComboBox.Items.Add(item);
            }
            //TODO: Нужно получить массив строк с названиями городов и добавить их в оба комбобокса
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {     
            new MainUserMenu(userInfo).Show();
            this.Close();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            avalibleFlights = new List<string>();
        
            string[,] result =  new FlightControlPanel().SearchFlights(FlightFromComboBox.SelectedItem.ToString(),FlightToComboBox.SelectedItem.ToString());
            this.result = result;
            try
            {
                for (int i = 0; i < result.GetLength(0); i++)
                {                
                        avalibleFlights.Add(String.Format("ID: {0}; AirCraft: {1}; DateTime: {2} ", result[i, 0], result[i, 1], result[i, 2]));    
                }
                if (avalibleFlights.Count != 0)
                {
                    AvalibleFlightsComboBox.ItemsSource = avalibleFlights;
                    MessageBox.Show("Найдено рейсов с указаным направление: " + avalibleFlights.Count);
                }
                
                else
                    MessageBox.Show("Рейсов с указаным маршрутом не найдено ");

            }
            catch(Exception)
            {
                MessageBox.Show("Рейсов с указаным маршрутом не найдено ");
            }
            
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int startOfId = AvalibleFlightsComboBox.Text.IndexOf(" ")+1;
                int IdLenght = AvalibleFlightsComboBox.Text.IndexOf(";")- startOfId;
                new BuyWindow(userInfo, AvalibleFlightsComboBox.Text.Substring(startOfId,IdLenght)).Show();
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Рейс не выбран!");
            }  
        }

        
    }
}
