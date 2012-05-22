using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4.Models.Repository
{
    interface IRepository<T>
    {
        IEnumerable<T> GetAll();
       
        T GetById(int id);

        void Save(T item);

        void Update(T item);

        void Delete(T item);
    }
}
