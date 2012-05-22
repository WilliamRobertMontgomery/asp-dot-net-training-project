using System;
using System.Linq;
using System.Web;
using NHibernate;
using System.Collections.Generic;

namespace MvcWebProjectNEW.Models.VesenniDataAccess
{
    public class Repository : IRepository
    {
        private ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        public T GetById<T>(Guid id)
        {
            var temp = _session.Get<T>(id);
            return temp;
        }

        public IList<T> GetAll<T>()
        {
           var criteria = _session.CreateCriteria(typeof(T));
           return new List<T>(criteria.List<T>());
        }

        public void AddEntity<T>(T entity)
        {
            _session.BeginTransaction();
            _session.Save(entity);
            _session.Transaction.Commit();
        }

        public void UpdateEntity<T>(T entity)
        {
            _session.BeginTransaction();
            _session.Update(entity);
            _session.Transaction.Commit();
        }

        public void DeleteEntity<T>(T entity)
        {
            _session.BeginTransaction();
            _session.Delete(entity);
            _session.Transaction.Commit();
        }

        public void DeleteById<T>(Guid id)
        {
            _session.BeginTransaction();
            var entity = _session.Get<T>(id);
            _session.Delete(entity);
            _session.Transaction.Commit();
        }
    }
}