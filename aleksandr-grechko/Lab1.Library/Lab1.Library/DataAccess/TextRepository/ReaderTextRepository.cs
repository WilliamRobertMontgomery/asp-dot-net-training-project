using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.Library.Entities;
using System.IO;

namespace Lab1.Library.DataAccess
{
    public class ReaderTextRepository : ReaderRepository
    {
        private const string FILE_NAME = @"Text\Readers.txt";

        private const int RECORD_SIZE = 512;

        private const int MAX_RECORD_STRING_LENGTH = (RECORD_SIZE - 2) / 2;

        public ReaderTextRepository()
        {
            if (!Directory.GetParent(FILE_NAME).Exists) Directory.GetParent(FILE_NAME).Create();
            if (!File.Exists(FILE_NAME)) File.Create(FILE_NAME).Close();
        }

        public override Reader GetItem(Guid id)
        {
            using (BinaryReader binaryReader = new BinaryReader(File.Open(FILE_NAME, FileMode.Open), Encoding.Unicode))
            {
                while (binaryReader.PeekChar() != -1)
                {
                    string[] arrayString = binaryReader.ReadString().Split('|');
                    if (arrayString[0] == id.ToString())
                    {
                        return CreateReader(arrayString);
                    }
                }
                return null;
            }
        }

        public override IEnumerable<Reader> GetItems()
        {
            using (BinaryReader binaryReader = new BinaryReader(File.Open(FILE_NAME, FileMode.Open), Encoding.Unicode))
            {
                while (binaryReader.PeekChar() != -1)
                {
                    yield return CreateReader(binaryReader.ReadString().Split('|'));
                }
            }
        }

        public override void Save(Reader item)
        {
            int i = 0;
            using (BinaryReader binaryReader = new BinaryReader(File.Open(FILE_NAME, FileMode.Open), Encoding.Unicode))
            {
                while (binaryReader.PeekChar() != -1)
                {
                    string[] arrayString = binaryReader.ReadString().Split('|');
                    if (arrayString[0] == item.Id.ToString()) break;
                    i = i + 1;
                }
            }
            using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(FILE_NAME, FileMode.Open, FileAccess.Write), Encoding.Unicode))
            {
                binaryWriter.Seek(i * RECORD_SIZE, SeekOrigin.Begin);
                StringBuilder str = new StringBuilder(String.Join("|", item.Id.ToString(), item.FullName, item.Address));
                str.Append("|");
                str.Length = MAX_RECORD_STRING_LENGTH;
                binaryWriter.Write(str.ToString());
            }
        }

        public override void Remove(Reader item)
        {
            Remove(item.Id);
        }

        public override void Remove(Guid id)
        {
            List<String> listString = new List<String>();
            using (BinaryReader binaryReader = new BinaryReader(File.Open(FILE_NAME, FileMode.Open), Encoding.Unicode))
            {
                while (binaryReader.PeekChar() != -1)
                {
                    string str = binaryReader.ReadString();
                    string[] arrayString = str.Split('|');
                    if (arrayString[0] != id.ToString())
                    {
                        listString.Add(str);
                    }
                }
            }
            using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(FILE_NAME, FileMode.Create, FileAccess.Write), Encoding.Unicode))
            {
                foreach (string s in listString) 
                {
                    binaryWriter.Write(s);
                }
            }
        }

        public override IEnumerable<Reader> GetReadersByName(string fullName, bool matchWholeString)
        {
            using (BinaryReader binaryReader = new BinaryReader(File.Open(FILE_NAME, FileMode.Open), Encoding.Unicode))
            {
                while (binaryReader.PeekChar() != -1)
                {
                    string[] arrayString = binaryReader.ReadString().Split('|');
                    if (matchWholeString ? arrayString[1] == fullName : arrayString[1].Contains(fullName))
                    {
                        yield return CreateReader(arrayString);
                    }
                }
            }
        }

        private Reader CreateReader(string[] arrayString)
        {
            return new Reader(new Guid(arrayString[0]), arrayString[1], arrayString[2]);
        }

    }
}
