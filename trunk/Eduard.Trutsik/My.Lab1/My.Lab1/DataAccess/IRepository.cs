using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.Lab1.DataAccess
{
	public interface IRepository<T>
	{
		T getItem(int id);
		IEnumerable<T> getItems();
		void add(T item);
		void remove(T item);
		void remove(int id);
	}
}
