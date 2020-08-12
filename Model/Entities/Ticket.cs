
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Ticket : DataBaseEntity    
    {
        public string FlightID { get; set; }    
        public string UserNumber { get; set; }
        public string Site { get; set; }
        public bool IsActive { get; set; } //Активный неактивный билет(до вылета актив после неактив)

        public Ticket(string flightId, string userNumber)
        {
            FlightID = flightId;
            UserNumber = userNumber;
            IsActive = true;
        }
        public Ticket()
        {

        }

    }   
}
