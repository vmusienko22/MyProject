using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;
using System.Linq;
using Model.DataBase;

namespace Controller.DataBase
{

     public class DataBaseManagerAccounts : DataBaseManager<Account> 
    {
        public override string Path { get { return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Model\\DataBase\\Accounts_DataBase.xml"; ; } }




        public  Account Find(string login, string password)
        {
            List<Account> accounts = new List<Account>();
            XmlSerializer serializer = new XmlSerializer(accounts.GetType());
            if (!File.Exists(Path))
                CreateDB();

            using (FileStream fs = File.OpenRead(Path))
            {
                accounts = serializer.Deserialize(fs) as List<Account>;
            }
            try
            {
                var searchAccount = accounts.First(x => x.Login == login && x.Password == password);
                return searchAccount;
            }
            catch (Exception)
            {

                return null;
            }
                
        }
        

     
    }
}
