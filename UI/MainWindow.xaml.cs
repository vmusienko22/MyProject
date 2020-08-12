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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Controller;
using UI.AdminPanel;

namespace UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
               
        public MainWindow()
        {
            
            InitializeComponent();
            
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            string[] accountInfo = Authorization.SignIn(LoginTextBox.Text, PasswordBox.Password);
            if (accountInfo != null)
            {
                MessageBox.Show("Welcome, " + accountInfo[1] );
                if (Convert.ToBoolean(accountInfo[0]) == true)
                {
                    new MainAdminMenu().Show();
                }
                else
                {
                    new MainUserMenu(accountInfo).Show();
                    
                }

                this.Close();

            }
           
            else
            {
                MessageBox.Show("Неправильный логин или пароль");
            }
            
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {

            Frame.Navigate(new Registration());
                      
        }

        private void MainUserManuFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
