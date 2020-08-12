using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Plane : DataBaseEntity
    {
        public string Model { get; }

        public Plane(int id, string model)
        {
            Id = id;
            Model = model;
        }
        public Plane()
        {

        }
    }
}
