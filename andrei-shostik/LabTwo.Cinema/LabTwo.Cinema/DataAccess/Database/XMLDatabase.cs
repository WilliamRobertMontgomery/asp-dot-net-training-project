using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using LabTwo.Cinema.DataAccess;

namespace LabTwo.Cinema.DataAccess.Database
{
    public class XmlDataBase : DataBase
    {
        public XmlDataBase(string basePath)
            : base(basePath)
        {
            FileExtension = "xml";
        }

        internal override bool WriteData<T>(T data)
        {
            var typeofData = ((dynamic)data).ToArray().GetType();
            string filename = GenerateFileName(typeofData);
            var serializer = new XmlSerializer(typeofData);

            using (TextWriter writer = new StreamWriter(filename))
            {
                serializer.Serialize(writer, ((dynamic)data).ToArray());
            }

            return true;
        }

        internal override IEnumerable<T> ReadFile<T>()
        {
            string filename = GenerateFileName(typeof(T));
            var readData = InternalRead<T>(filename);
            if (readData == null)
            {
                throw new FileNotFoundException(string.Format("The file on this path {0} was not found", filename));
            }
            return readData;
        }

        protected override IEnumerable<T> InternalRead<T>(string filename)
        {
            if (File.Exists(filename))
            {
                var list = new List<T>();
                var serializer = new XmlSerializer(typeof(T));

                using (XmlReader reader = XmlReader.Create(filename))
                {
                    while (reader.ReadToFollowing(typeof(T).Name))
                    {
                        list.Add((T)serializer.Deserialize(reader));
                    }
                }
                if (list[0] == null)
                {
                    throw new ItemNotFoundException(string.Format("Item {0} not load.", typeof(T).Name));
                }
                return list;
            }
            return null;
        }
    }
}