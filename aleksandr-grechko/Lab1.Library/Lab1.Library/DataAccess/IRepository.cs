using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1.Library.DataAccess
{
	public interface IRepository<T> where T : class
	{
		T GetItem(Guid id);
		IEnumerable<T> GetItems();
		void Save(T item);
		void Remove(T item);
		void Remove(Guid id);
	}
}
