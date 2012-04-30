using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1.DataAccess
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Function get item
        /// </summary>
        /// <param name="id">int id</param>
        /// <returns>T item</returns>
        T GetItem(int id);
 
        /// <summary>
        /// Function get all items
        /// </summary>
        /// <returns>IEnumerable</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Add item
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Add(T item);

        /// <summary>
        /// Function delete item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>if item is delete return true</returns>
        bool Delete(int id);

        /// <summary>
        /// Function delete item by 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Delete(T item);
    }
}
