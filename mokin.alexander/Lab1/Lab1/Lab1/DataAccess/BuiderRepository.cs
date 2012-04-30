using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.Entities;
using System.IO;

namespace Lab1.DataAccess
{
    public class BuilderRepository : IRepository<Builder>
    {
        private const string filePath = "Builders.txt";

        public Builder GetItem(int id)
        {
            return GetAll().FirstOrDefault(builder => builder.id == id);
        }

        public IEnumerable<Builder> GetAll()
        {
            string[] builders = null;
            string[] builderFields;
            try
            {
                builders = File.ReadAllLines(filePath);
            }
            catch
            {
                return new Builder[] { new Builder(0, null) }.Select(x => x);
            }
            return builders.Select(builder =>
            {
                builderFields = builder.Split(',');
                return new Builder(Int32.Parse(builderFields[0]), builderFields[1]);
            });
        }

        public bool Add(Builder item)
        {
            FileInfo fi = new FileInfo(filePath);
            StreamWriter streamWriter = fi.AppendText();
            streamWriter.WriteLine(item.id.ToString() + ',' + item.name);
            streamWriter.Close();
            return true;
        }

        public bool Delete(int id)
        {
            var builders = GetAll().Where(builder => builder.id != id);
            StreamWriter streamWriter = new StreamWriter(filePath);
            foreach (var builder in builders)
            {
                streamWriter.WriteLine(builder.id.ToString() + ',' + builder.name);
            }
            streamWriter.Close();
            return true;
        }

        public bool Delete(Builder item)
        {
            var builders = GetAll().Where(builder => builder.id != item.id && builder.name != item.name);
            StreamWriter streamWriter = new StreamWriter(filePath);
            foreach (var builder in builders)
            {
                streamWriter.WriteLine(builder.id.ToString() + ',' + builder.name);
            }
            streamWriter.Close();
            return true;
        }
    }
}
