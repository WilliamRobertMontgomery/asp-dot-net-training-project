using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.Library.Entities;
using System.IO;

namespace Lab1.Library.DataAccess
{
    public class LibraryDepartmentTextRepository : LibraryDepartmentRepository
    {

        private const string FILE_NAME = @"Text\Departments.txt";

        private const int RECORD_SIZE = 256;

        private const int MAX_RECORD_STRING_LENGTH = (RECORD_SIZE - 2) / 2;

        public LibraryDepartmentTextRepository()
        {
            if (!Directory.GetParent(FILE_NAME).Exists) Directory.GetParent(FILE_NAME).Create();
            if (!File.Exists(FILE_NAME)) File.Create(FILE_NAME).Close();
        }

        public override LibraryDepartment GetItem(Guid id)
        {
            using (BinaryReader binaryReader = new BinaryReader(File.Open(FILE_NAME, FileMode.Open), Encoding.Unicode))
            {
                while (binaryReader.PeekChar() != -1)
                {
                    string[] arrayString = binaryReader.ReadString().Split('|');
                    if (arrayString[0] == id.ToString())
                    {
                        return CreateLibraryDepartment(arrayString);
                    }
                }
                return null;
            }
        }

        public override IEnumerable<LibraryDepartment> GetItems()
        {
            using (BinaryReader binaryReader = new BinaryReader(File.Open(FILE_NAME, FileMode.Open), Encoding.Unicode))
            {
                while (binaryReader.PeekChar() != -1)
                {
                    yield return CreateLibraryDepartment(binaryReader.ReadString().Split('|'));
                }
            }
        }

        public override void Save(LibraryDepartment item)
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
                StringBuilder str = new StringBuilder(String.Join("|", item.Id.ToString(), item.Name, item.IsAbonement.ToString()));
                str.Append("|");
                str.Length = MAX_RECORD_STRING_LENGTH;
                binaryWriter.Write(str.ToString());
            }
        }

        public override void Remove(LibraryDepartment item)
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

        private LibraryDepartment CreateLibraryDepartment(string[] arrayString)
        {
            return new LibraryDepartment(new Guid(arrayString[0]), arrayString[1], Convert.ToBoolean(arrayString[2]));
        }

    }
}
