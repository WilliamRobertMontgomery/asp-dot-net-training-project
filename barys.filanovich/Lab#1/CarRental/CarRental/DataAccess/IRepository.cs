using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRental.DataAccess
{
    interface IRepository<T>
    {
        T[] Read();
        void Save(T item);
        void Remove(T item);
    }
}
