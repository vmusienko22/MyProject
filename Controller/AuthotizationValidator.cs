using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Controller
{
    /// <summary>
    /// Класс хранящий методы проверки валидности полей авторизации
    /// </summary>
    public static class AuthotizationValidator
    {
     
        public static bool CheckLogin(string login)
        { 
            return Regex.IsMatch(login, "[a-zA-z0-9]+");
        }
        /// <summary>
        /// </summary>
        /// <param name="password"> Минимальная длинна пароля 6 символов, должен иметь хоть один специальный символ (@,# и т.д.) </param>
        /// <returns></returns>
        public static bool CheckPassword(string password)
        {
            return Regex.IsMatch(password, @"(?=.*[0-9])(?=.*[!@#$%^&*])(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z!@#$%^&*]{6,}");
        }

        public static bool CheckEmail(string email)
        {      
            return Regex.IsMatch(email, @"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$");
        }

        /// <summary>
        /// </summary>
        /// <param name="phoneNumber"> Должен соответствовать шаблону "0ХХХХХХХХХ" </param>
        /// <returns></returns>
        public static bool CheckPhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"^0\d{9}$");
        }

        public static bool[] Validator(Account account)
        {
            bool[] array = new bool[4];

            array[0]=CheckLogin(account.Login);
            array[1]=CheckPassword(account.Password);
            array[2]=CheckEmail(account.Email);
            array[3]=CheckPhoneNumber(account.PhoneNumber);

            return array;
            
        }


    }
}
