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
        private const string FileName = @"Text\Readers.txt";

        private const int RecordSize = 512;

        private const int MaxRecordStringLength = (RecordSize - 2) / 2;

        public ReaderTextRepository()
        {
            if (!Directory.GetParent(FileName).Exists) Directory.GetParent(FileName).Create();
            if (!File.Exists(FileName)) File.Create(FileName).Close();
        }

        public override Reader GetItem(Guid id)
        {
            using (BinaryReader binaryReader = new BinaryReader(File.Open(FileName, FileMode.Open), Encoding.Unicode))
            {
                while (binaryReader.PeekChar() != -1)
                {
                    string[] arrayString = binaryReader.ReadString().Split('|');
                    if (arrayString[0] == id.ToString())
                    {
                        return CreateItem(arrayString);
                    }
                }
                return null;
            }
        }

        public override IEnumerable<Reader> GetItems()
        {
            using (BinaryReader binaryReader = new BinaryReader(File.Open(FileName, FileMode.Open), Encoding.Unicode))
            {
                while (binaryReader.PeekChar() != -1)
                {
                    yield return CreateItem(binaryReader.ReadString().Split('|'));
                }
            }
        }

        public override void Save(Reader item)
        {
            int i = 0;
            using (BinaryReader binaryReader = new BinaryReader(File.Open(FileName, FileMode.Open), Encoding.Unicode))
            {
                while (binaryReader.PeekChar() != -1)
                {
                    string[] arrayString = binaryReader.ReadString().Split('|');
                    if (arrayString[0] == item.Id.ToString()) break;
                    i = i + 1;
                }
            }
            using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(FileName, FileMode.Open, FileAccess.Write), Encoding.Unicode))
            {
                binaryWriter.Seek(i * RecordSize, SeekOrigin.Begin);
                StringBuilder str = new StringBuilder(String.Join("|", item.Id.ToString(), item.FullName, item.Address));
                str.Append("|");
                str.Length = MaxRecordStringLength;
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
            using (BinaryReader binaryReader = new BinaryReader(File.Open(FileName, FileMode.Open), Encoding.Unicode))
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
            using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(FileName, FileMode.Create, FileAccess.Write), Encoding.Unicode))
            {
                foreach (string s in listString) 
                {
                    binaryWriter.Write(s);
                }
            }
        }

        public override IEnumerable<Reader> GetReadersByName(string fullName, bool matchWholeString)
        {
            using (BinaryReader binaryReader = new BinaryReader(File.Open(FileName, FileMode.Open), Encoding.Unicode))
            {
                while (binaryReader.PeekChar() != -1)
                {
                    string[] arrayString = binaryReader.ReadString().Split('|');
                    if (matchWholeString ? arrayString[1] == fullName : arrayString[1].Contains(fullName))
                    {
                        yield return CreateItem(arrayString);
                    }
                }
            }
        }

        private Reader CreateItem(string[] arrayString)
        {
            return new Reader(new Guid(arrayString[0]), arrayString[1], arrayString[2]);
        }

    }
}
