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
    public class DataBaseManagerTickets : DataBaseManager<Ticket>
    {
        public override string Path { get { return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Model\\DataBase\\Tickets_DataBase.xml"; ; } }
      
       //public bool Save(Ticket ticket)
       //{
       //    StreamWriter streamWriter = File.CreateText("D:\\MyTicket.txt");
       //    streamWriter.WriteLine("Рейс: " + ticket.FlightID);
       //    streamWriter.WriteLine("Номер телефона покупателя: " + ticket.UserNumber);
       //    streamWriter.WriteLine("Время:");
       //    streamWriter.WriteLine("Цена:");
       //
       //    return true;
       //}
       
       
    }
}
