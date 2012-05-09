using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.LabWork1.Policlinic.DataAccess
{
	public interface IRepository<T>
	{
		T Get(int id);
		IEnumerable<T> GetAll();
		void Save(T item);
		void Remove(T item);
		void Remove(int id);
		void Update(T item);
	}
}
