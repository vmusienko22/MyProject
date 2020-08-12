using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public enum FlightStatus
    {
        Сheck_In, 
        Сheck_In_Open, 
        Open    
    }

    public class Flight : DataBaseEntity
    {
       
        public string DeparturePoint { get; set; }
        public string DestinationPoint { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public int PlaneID { get; set; }

        public FlightStatus Staus;

    }
}
