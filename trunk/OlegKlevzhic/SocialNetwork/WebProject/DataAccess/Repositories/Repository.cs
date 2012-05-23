using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace WebProject.DataAccess.Repositories
{
	public class Repository<T> : IRepository<T>
	{
		private ISession _session;

		public Repository(ISession session)
		{
			_session = session;
		}

		public void Save(T item)
		{
			using (ITransaction transaction = _session.BeginTransaction())
			{
				_session.SaveOrUpdate(item);
				transaction.Commit();
			}
		}

		public void Save(IEnumerable<T> items)
		{
			foreach (var item in items)
			{
				Save(item);
			}
		}

		public IEnumerable<T> GetAll()
		{
			return new List<T>(_session.CreateCriteria(typeof(T)).List<T>());
		}

		public T Get(Guid id)
		{
			return _session.Get<T>(id);
		}

		public void Remove(T item)
		{
			using (ITransaction transaction = _session.BeginTransaction())
			{
				_session.Delete(item);
				transaction.Commit();
			}
		}
	}
}
