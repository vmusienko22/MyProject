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
    /// Логика взаимодействия для MainUserManu2.xaml
    /// </summary>
    public partial class UserPersonalData : Window
    {
        private string[] userInfo;
        public string IsAdministrator { get; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Login { get; }
        public string Password { get; set; }


        public UserPersonalData(string[] userInfo)
        {
            this.userInfo = userInfo;
            InitializeComponent();
            IsAdministrator = userInfo[0];
            UserName = userInfo[1];
            NameTextBox.Text = UserName;
            LastName = userInfo[2];
            LastNameTextBox.Text = LastName;
            Email = userInfo[3];
            EmailTextBox.Text = Email;
            PhoneNumber = userInfo[4];
            PhoneNumberTextBox.Text = PhoneNumber;
            Login = userInfo[5];
            LoginTextBox.Text = Login;
            Password = userInfo[6];
        }

        

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            UserName = NameTextBox.Text;
            LastName = LastNameTextBox.Text;
            Email = EmailTextBox.Text;
            PhoneNumber = PhoneNumberTextBox.Text;
            Password = PasswordTextBox.Text;


            string[] accountInfo = { IsAdministrator, UserName, LastName, Email, PhoneNumber, Login, Password };
            if (Authorization.ChnageAccountInfo(accountInfo))
                MessageBox.Show(" Successful! ");
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            
            new MainUserMenu(userInfo).Show();
            this.Close();
        }
    }
}

