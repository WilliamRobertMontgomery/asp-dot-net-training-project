using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.Lab4.DataAccess
{
	public interface IRepository<T>
	{
		T GetItem(int id);
		IEnumerable<T> GetItems();
		void Add(T item);
		void Remove(T item);
		void Remove(int id);
		void Update(T item);
	}
}
