using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public interface IDataBase<T>
    {
        IEnumerable<T> Value { get; }
        void Add(T value);
    }
}
