
using Model.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model.DataBase
{
    public class DataBaseManagerFlight : DataBaseManager<Flight>
    {
        public override string Path { get { return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Model\\DataBase\\Flights_DataBase.xml"; ; } }
        

        public  List<Flight> FindByPoints(string departurePoint , string destinationPoint)
        {
            List<Flight> accounts = new List<Flight>();
            XmlSerializer serializer = new XmlSerializer(accounts.GetType());
            if (!File.Exists(Path))
                CreateDB();

            using (FileStream fs = File.OpenRead(Path))
            {
                accounts = serializer.Deserialize(fs) as List<Flight>;
            }
            try
            {   
                var searchAccount = accounts.FindAll(x => x.DeparturePoint == departurePoint && x.DestinationPoint == destinationPoint);
                return searchAccount;
            }
            catch (Exception)
            {

                return null;
            }
        }

       


    }
}
