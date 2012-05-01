using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1Airport
{
    interface IRepository<T>
    {
        T GetElement(int id);
        IEnumerable<T> GetAll();
        void AddElement(T element);
        void UpdateElement(T element);
        void DeleteElement(int id);
        void DeleteElement(T element);
    }
}
