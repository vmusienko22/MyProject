using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;
using Controller.DataBase;

namespace Controller
{
    public class Authorization
    {

        
        public static string[] SignIn(string login, string password)
        {
            Account account = new DataBaseManagerAccounts().Find(login, password);
            if (account != null)
            {
                string[] accountInfo = new string[7];
                accountInfo[0] = account.IsAdministrator.ToString();
                accountInfo[1] = account.Name;
                accountInfo[2] = account.LastName;
                accountInfo[3] = account.Email;
                accountInfo[4] = account.PhoneNumber;
                accountInfo[5] = account.Login;
                accountInfo[6] = account.Password;
                return accountInfo;
            }
            else
                return null;

        }

        public static bool ChnageAccountInfo(string[] accountInfo)
        {
            Account account = new Account();

            account.IsAdministrator = Convert.ToBoolean(accountInfo[0]);
            account.Name = accountInfo[1];
            account.LastName = accountInfo[2];

            if (AuthotizationValidator.CheckEmail(accountInfo[3]))
                account.Email = accountInfo[3];
            else
            {
                MessageBox.Show("Invalid Email");
                return false;
            }

            if (AuthotizationValidator.CheckPhoneNumber(accountInfo[4]))
                account.PhoneNumber = accountInfo[4];

            else
            {
                MessageBox.Show("Invalid phone number ");
                return false;
            }
            
            account.Login =  accountInfo[5]; ;

            if (AuthotizationValidator.CheckPassword(accountInfo[6]))
                account.Password= accountInfo[6];
            else
            {
                MessageBox.Show("Invalid password ");
                return false;
            }

            return new DataBaseManagerAccounts().ChangeInfo(account);
            

        }
    }
}
