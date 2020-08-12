using Model.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Entities;

namespace Controller
{
    /// <summary>
    /// Класс содержащий методы предназначеные для управления аккаунтами
    /// (Добавление и удаление Администраторов и Пользователей)
    /// </summary>
    public class Owvner
    {  // Тест создания баз данных 
        public static bool Test()
        {
            Flight flight = new Flight() { PlaneID = 1566, DeparturePoint = "Киев", DestinationPoint = "Варшава", DepartureDateTime = DateTime.Now, Staus = FlightStatus.Сheck_In };
            DataBaseManagerFlight dataBase = new DataBaseManagerFlight();
            flight = dataBase.Add(flight);
            flight.DestinationPoint = "Токио";
            dataBase.ChangeInfo(flight);
            var searchFlight = dataBase.Find(flight.Id);
                
                // new DataBaseManagerPlane().CreateDB();
           // new DataBaseManagerTickets().CreateDB();
            

            return true;
        }

        // public static bool Test1()
        // {
        //     new DataBaseManagerFlight().Add(new Flight() { Id = "0001",PlaneID = "Airobus 350", Staus = FlightStatus.Сheck_In, DeparturePoint = "Киев", DestinationPoint = "Львов", DepartureDate = "01/01/21", DepartureTime = "10:15"});
        //     return true;
        // }

    }
}
