using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1Airport
{
    interface IRepository<T>
    {
        /// <summary>
        /// Function get all items
        /// </summary>
        /// <returns>IQueryable</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Save or update item
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>if item is saved return true</returns>
        bool Save(T entity);

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
        bool Delete(T entity);
    }
}
