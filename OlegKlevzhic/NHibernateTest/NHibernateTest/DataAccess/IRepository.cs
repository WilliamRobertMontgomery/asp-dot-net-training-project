using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NHibernateTest.DataAccess
{
	public interface IRepository<T>
	{
		void Save(T item);
		void Save(IEnumerable<T> items);
		T Read(Guid id);
		IEnumerable<T> ReadAll();
		void Delete(T item);
	}
}
