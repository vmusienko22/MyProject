using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace Controller
{

    public class Account: DataBaseEntity
    {             
        public bool IsAdministrator { get; set; }       
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Login { get; set; }        
        public string Password { get; set; }
    }
}
