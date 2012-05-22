using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace MvcWebProjectNEW.Models.VesenniDataAccess
{
    public interface IRepository
    {
        T GetById<T>(Guid id);
        IList<T> GetAll<T>();
        void AddEntity<T>(T entity);
        void UpdateEntity<T>(T entity);
        void DeleteEntity<T>(T entity);
        void DeleteById<T>(Guid id);
    }
}
