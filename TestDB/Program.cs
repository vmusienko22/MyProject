using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.SQL;
using MySql.Data.MySqlClient;

namespace TestDB
{
    class Program
    {// Разбираемся как работать с SQL
        static void Main(string[] args)
        {
            //Подготовим данные которые нам нужно записать
            string name = "Name";
            string lastName = "SecName";
            string fathersName = "Olexandrovych";
            string phoneNumber = "0991996410";
            string email = "myEmail@gmail.com";
            string login = "Ivanovych378";
            string password = "Password@123";
            string position = "Manager";

            // Вот такой запрос будем делать в нашу БД
            string dataInsert = $"INSERT INTO Accounts (Name,SecondName,Patronymic,PhoneNumber,Email,Login,Password,Position) VALUES ('{name}','{lastName}','{fathersName}','{phoneNumber}','{email}','{login}','{password}','{position}');";

            Console.WriteLine("Getting Connection ...");



            SqlConnection conn = DBUtils.GetDBConnection(); // Получаем наше соеденение с БД в виде экземпляра класса
            SqlDataReader dataReader;// Класс на котором нужно вызвать отправку запрса
            

            try
            {
                Console.WriteLine("Openning Connection ...");           
                
                conn.Open(); // Обязательно открываем соеденение с БД     

                SqlCommand cmd = new SqlCommand(dataInsert, conn);// Создаем Обьектное представление нашего запроса (запрос,подключение)
                dataReader = cmd.ExecuteReader(); // Отправляем запрос

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            

           



            Console.Read();
        }
    }
}
