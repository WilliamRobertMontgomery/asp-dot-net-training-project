using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using My.LabWork1.Policlinic.Entities;

namespace My.LabWork1.Policlinic.Tools
{
	public class Serializer<T> where T : EntityBase
	{
		private string filePath = String.Empty;
		private BinaryFormatter formatter;
		private FileStream stream;

		public Serializer(string filePath)
		{
			this.filePath = filePath;
			this.formatter = new BinaryFormatter();
		}

		public void Save(T item)
		{
			var list = GetAll();
			list.Add(item);
			stream = File.OpenWrite(this.filePath);
			formatter.Serialize(stream, list);
			stream.Close();
		}

		public T Get(int id)
		{
			return GetAll().FirstOrDefault(x => x.Id == id);
		}

		public List<T> GetAll()
		{
			var buf = File.ReadAllBytes(this.filePath);
			if (buf.Count() != 0)
			{
				return (List<T>)formatter.Deserialize(new MemoryStream(buf));
			}
			else
			{
				return new List<T>();
			}
		}

		public void Remove(int id)
		{
			var list = GetAll();
			list.RemoveAll(x => x.Id == id);
			stream = File.OpenWrite(this.filePath);
			formatter.Serialize(stream, list);
			stream.Close();
		}

		public void Remove(T item)
		{
			GetAll().Remove(item);
		}
	}
}
