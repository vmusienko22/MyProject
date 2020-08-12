using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Controller
{
    public class Registrator
    {
        private static Database dataBase = new Database();

       
       
        private static bool Regin(Account account)
        {
            var encodedPassword = Encode(account.Password);

            if (dataBase.Accounts.Count() == 0 || !dataBase.Accounts.Any(p => p.Login == account.Login))
            {
                dataBase.Add(account);
                return true;
            }
            else
                return false;                
            
        }

        private static string Encode(string password)
        {
            using (var md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(password.ToCharArray().Select(x => (byte)x).ToArray());
                return string.Join(string.Empty, hash);
            }
        }

        //TODO:Когда будет готова форма регистрации добавить возвращаемое значение в качестве массива строк которые потом будут выводиться напротив текстбоксов
        public static void Register(string name, string lastname, string login, string password, string phone, string email)// В разработке
        {
            Account testaccount = new Account();
            testaccount.Name = name;
            testaccount.LastName = lastname;
            testaccount.IsAdministrator = false;
            testaccount.Login = login;
            testaccount.Password = password;
            testaccount.PhoneNumber = phone;
            testaccount.Email = email;



            bool[] array = AuthotizationValidator.Validator(testaccount);

            if (!array[0])

                MessageBox.Show("Invalid login");

            if (!array[1])

                MessageBox.Show("Invalid password");

            if (!array[2])

                MessageBox.Show("Invalid Email");

            if (!array[3])

                MessageBox.Show("Invalid phone");

            if (!array.Any(x => x == false))
            {
                if (Registrator.Regin(testaccount))
                {
                    MessageBox.Show("Registrtion successfully");
                }
                else
                {
                    MessageBox.Show("This login alredy exist");
                }
            }
        }

    }
}
