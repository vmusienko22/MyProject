using Model.DataBase;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class FlightControlPanel
    {
        public string[,] SearchFlights(string departurePoint, string destinationPoint)
        {
            
            Flight[] flights = new DataBaseManagerFlight().FindByPoints(departurePoint, destinationPoint).ToArray();
            string[,] result = new string[flights.Length, 4];

            for (int i = 0; i < flights.Length; i++)
            {
                result[i, 0] = flights[i].Id.ToString();
                result[i, 1] = flights[i].PlaneID.ToString();
                result[i, 2] = flights[i].DepartureDateTime.ToString();
                
            }

            return result;
        }
        public string[] SearchFlight(int id)
        {
            Flight flight = new DataBaseManagerFlight().Find(id);
            string[] result = new string[5];
            result[0] = flight.Id.ToString();
            result[1] = flight.DeparturePoint;
            result[2] = flight.DestinationPoint;
            result[3] = flight.DepartureDateTime.ToString();
            result[4] = flight.PlaneID.ToString();
            
            return result;
        }

        public static bool SaveTicket(string flightId, string userPhoneNumber, string departurePoint, string destinationPoint, string departureDatetime)
        {
          Ticket ticket = new Ticket(flightId, userPhoneNumber) { IsActive = true };
            new DataBaseManagerTickets().Add(ticket);
            return true;
        }
    }
}
