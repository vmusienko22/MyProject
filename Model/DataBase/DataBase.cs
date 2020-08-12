using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Controller
{
    public class Database : IDataBase<Account>
    {
        public static string Filename = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Model\\DataBase\\Accounts_DataBase.xml";
        static readonly XmlSerializer Serializer = new XmlSerializer(typeof(Account[]));

        public IEnumerable<Account> Accounts
        {
            get
            {
                return DeserializePersons();
            }
        }

        public IEnumerable<Account> Value => throw new NotImplementedException();

        private static IEnumerable<Account> DeserializePersons()
        {
            try
            {
                using (var fileStream = new FileStream(Filename, FileMode.Open))
                {
                    return (IEnumerable<Account>)Serializer.Deserialize(fileStream);
                }
            }
            catch
            {
                return Enumerable.Empty<Account>();
            }
        }

        public void Add(Account account)
        {
            var accounts = DeserializePersons().ToList();
            accounts.Add(account);
            using (var fileStream = new FileStream(Filename, FileMode.Create))
            {
                Serializer.Serialize(fileStream, accounts.ToArray());
            }
        }
    }
}
