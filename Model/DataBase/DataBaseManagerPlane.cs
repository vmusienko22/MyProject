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
    public class DataBaseManagerPlane : DataBaseManager<Plane>
    {
        public override string Path { get { return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Model\\DataBase\\Planes_DataBase.xml"; ; } }

        
       
    }
}
