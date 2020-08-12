using Controller;
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
    public abstract  class DataBaseManager<T>
    {
        public abstract string Path { get; }
        static readonly XmlSerializer Serializer = new XmlSerializer(typeof(T[]));



        /// <summary>
        /// Метод для создания БД выбраного типа
        /// </summary>
        /// <returns></returns>
        public bool CreateDB()
        {
            List<T> accounts = new List<T>();
            XmlSerializer xmlSerializer = new XmlSerializer(accounts.GetType());
            using (FileStream file = File.Create(Path))
            {
                xmlSerializer.Serialize(file, accounts);
            }
            return true;
        }

        private IEnumerable<T> DeserializeEntity()
        {
            try
            {
                using (var fileStream = new FileStream(Path, FileMode.Open))
                {
                    return (IEnumerable<T>)Serializer.Deserialize(fileStream);
                }
            }
            catch
            {
                return Enumerable.Empty<T>();
            }
        }

        /// <summary>
        /// Метод добавления элемента в БД, присваивает элементу новый Id 
        /// </summary>
        /// <param name="value"></param>
        public virtual T Add(T value)
        { 
            var entityCollection = DeserializeEntity().ToList();
            dynamic dyn = value;
            dyn.Id = entityCollection.Count + 1;
            
            entityCollection.Add(dyn);


            using (var fileStream = new FileStream(Path, FileMode.Create))
            {
                Serializer.Serialize(fileStream, entityCollection.ToArray());
            }

            return dyn;
        }
        
        /// <summary>
        /// Метод поиска Элемента по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public  T Find(int id)
        {
            var entityCollection = DeserializeEntity().ToList();

            if (!File.Exists(Path))
                CreateDB();

            
            try
            {

                foreach (dynamic item in entityCollection)
                {
                    if (item.Id == id)
                    {
                        return item;
                    }
                }
                return default(T);
            }
            catch (Exception)
            {
           
                return default(T);
            }
        }

        /// <summary>
        /// Заменяет элемент в БД с таким же Id новым элементом
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public  bool ChangeInfo(T value)
        {
            dynamic dValue = value;
            dynamic valueCollection = DeserializeEntity().ToList();
            T newValue = default(T);

            
            try
            {

                //  flight = flights.First(x => x.Id == value.Id);

                // flight = from  x in flights
                //                  where 
                //                  x.Id ==  dValue.Id
                //                  select x;
                foreach (dynamic item in valueCollection)
                {
                    if (item.Id == dValue.Id)
                    {
                        newValue = item;
                        break;
                    }
                }

               
                valueCollection[valueCollection.IndexOf(newValue)] = value;

            }
            catch (Exception)
            {
                return false;
            }


            using (FileStream file = File.Create(Path))
            {
                Serializer.Serialize(file, valueCollection.ToArray());
            }


            return true;
        }


        

    }

    
}
