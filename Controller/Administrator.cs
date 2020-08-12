using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DataBase;
using Model.Entities;

namespace Controller
{
    public class Administrator // Хранит методы по управлению контентом!(Добавление рейсов...?)
    {
        public static void AddFlight( string departurepoint, string destinationpoint, string departuretime, string departuredate, string planeId)
        {
            

            Flight testflight = new Flight();       
            testflight.PlaneID = Convert.ToInt32(planeId);
            testflight.DeparturePoint = departurepoint;
            testflight.DestinationPoint = destinationpoint;
            testflight.DepartureDateTime = Convert.ToDateTime(departuredate +" "+ departuretime);   //   "06 July 2008 7:32:47 AM"      
            testflight.Staus = FlightStatus.Сheck_In_Open;

            new DataBaseManagerFlight().Add(testflight);
            //Актальная версия)
        }

        public static void AddPlane()
        {

        }

        public static void RemoveFlight()
        {

        }

        public static void RemovePlane()
        {

        }

        public static void ChangeFlightInfo()
        {

        }
    }
}

