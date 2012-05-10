using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using My.LabWork1.Policlinic.Entities;
using My.LabWork1.Policlinic.Tools;

namespace My.LabWork1.Policlinic.DataAccess
{
	public class Repository<T> : IRepository<T> where T : EntityBase
	{
		Serializer<T> context;

		public Repository(string path)
		{
			if (typeof(Specialization).Equals(typeof(T)))
			{
				context = new Serializer<T>(path + "Specializations.txt");
			}
			if (typeof(Doctor).Equals(typeof(T)))
			{
				context = new Serializer<T>(path + "Doctors.txt");
			}
			if (typeof(Pacient).Equals(typeof(T)))
			{
				context = new Serializer<T>(path + "Pacients.txt");
			}
			if (typeof(Record).Equals(typeof(T)))
			{
				context = new Serializer<T>(path + "Records.txt");
			}
		}

		public T Get(int id)
		{
			return context.Get(id);
		}

		public IEnumerable<T> GetAll()
		{
			return context.GetAll();
		}

		public void Save(T item)
		{
			context.Save(item);
		}

		public void Remove(T item)
		{
			Remove(item.Id);
		}

		public void Remove(int id)
		{
			context.Remove(id);
		}

		public void Update(T item)
		{
			Remove(item);
			Save(item);
		}
	}
}
