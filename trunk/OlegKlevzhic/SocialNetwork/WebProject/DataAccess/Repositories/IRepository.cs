using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebProject.DataAccess.Repositories
{
	public interface IRepository<T>
	{
		void Save(T item);
		void Save(IEnumerable<T> items);
		T Get(Guid id);
		IEnumerable<T> GetAll();
		void Remove(T item);
	}
}
