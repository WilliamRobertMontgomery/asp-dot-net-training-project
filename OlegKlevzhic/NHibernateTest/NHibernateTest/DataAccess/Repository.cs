using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace NHibernateTest.DataAccess
{
	public class Repository<T> : IRepository<T>
	{
		private ISession session;

		public Repository(ISession session)
		{
			this.session = session;
		}

		public void Save(T item)
		{
			session.SaveOrUpdate(item);
		}

		public void Save(IEnumerable<T> items)
		{
			foreach (var item in items)
			{
				Save(item);
			}
		}

		public IEnumerable<T> ReadAll()
		{
			return new List<T>(session.CreateCriteria(typeof(T)).List<T>());
		}

		public T Read(Guid id)
		{
			return session.Get<T>(id);
		}

		public void Delete(T item)
		{
			session.Delete(item);
		}
	}
}
