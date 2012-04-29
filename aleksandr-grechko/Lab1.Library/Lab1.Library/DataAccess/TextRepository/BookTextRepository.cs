using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.Library.Entities;
using System.IO;

namespace Lab1.Library.DataAccess
{
	public class BookTextRepository : BookRepository
	{

        private const string FILE_NAME = @"Text\Books.txt";

        /*
        * AUTHOR: Mikalai Strylets
        * REVIEW: The recommended naming and capitalization convention is to use Pascal casing for constants.
        * DETAILS: A constant is a static field. For details see
         * http://msdn.microsoft.com/en-us/library/ms229012.aspx
        */
        private const int RECORD_SIZE = 512;

        private const int MAX_RECORD_STRING_LENGTH = (RECORD_SIZE - 2) / 2;
       
        public BookTextRepository(LibraryDepartmentRepository libraryDepartmentRepository)
		{
			this.libraryDepartmentRepository = libraryDepartmentRepository;

            if (!Directory.GetParent(FILE_NAME).Exists) Directory.GetParent(FILE_NAME).Create();
            if (!File.Exists(FILE_NAME)) File.Create(FILE_NAME).Close();
        }

        public override Book GetItem(Guid id)
        {
            using (BinaryReader binaryReader = new BinaryReader(File.Open(FILE_NAME, FileMode.Open), Encoding.Unicode))
            {
                while (binaryReader.PeekChar() != -1)
                {
                    string[] arrayString = binaryReader.ReadString().Split('|');
                    if (arrayString[0] == id.ToString())
                    {
                        return CreateBook(arrayString);
                    }
                }
                return null;
            }
        }

        public override IEnumerable<Book> GetItems()
        {
            using (BinaryReader binaryReader = new BinaryReader(File.Open(FILE_NAME, FileMode.Open), Encoding.Unicode))
            {
                while (binaryReader.PeekChar() != -1)
                {
                    yield return CreateBook(binaryReader.ReadString().Split('|'));
                }
            }
        }

        public override void Save(Book item)
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
                StringBuilder str = new StringBuilder(
                    String.Join("|", item.Id.ToString(), item.Author, item.Title, item.Year.ToString(), item.Department.Id.ToString()));
                str.Append("|");
                str.Length = MAX_RECORD_STRING_LENGTH;
                binaryWriter.Write(str.ToString());
            }
            libraryDepartmentRepository.Save(item.Department);
        }

        public override void Remove(Book item)
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

        public override IEnumerable<Book> GetBooksByAuthor(string author, bool matchWholeString)
        {
            using (BinaryReader binaryReader = new BinaryReader(File.Open(FILE_NAME, FileMode.Open), Encoding.Unicode))
            {
                while (binaryReader.PeekChar() != -1)
                {
                    string[] arrayString = binaryReader.ReadString().Split('|');
                    if (matchWholeString ? arrayString[1] == author : arrayString[1].Contains(author))
                    {
                        yield return CreateBook(arrayString);
                    }
                }
            }
        }

        public override IEnumerable<Book> GetBooksByTitle(string title, bool matchWholeString)
        {
            using (BinaryReader binaryReader = new BinaryReader(File.Open(FILE_NAME, FileMode.Open), Encoding.Unicode))
            {
                while (binaryReader.PeekChar() != -1)
                {
                    string[] arrayString = binaryReader.ReadString().Split('|');
                    if (matchWholeString ? arrayString[2] == title : arrayString[2].Contains(title))
                    {
                        yield return CreateBook(arrayString);
                    }
                }
            }
        }

        public override IEnumerable<Book> GetBooksByDepartment(LibraryDepartment department)
        {
            using (BinaryReader binaryReader = new BinaryReader(File.Open(FILE_NAME, FileMode.Open), Encoding.Unicode))
            {
                while (binaryReader.PeekChar() != -1)
                {
                    string[] arrayString = binaryReader.ReadString().Split('|');
                    if (arrayString[4] == department.Id.ToString())
                    {
                        yield return CreateBook(arrayString);
                    }
                }
            }
        }

        private Book CreateBook(string[] arrayString)
        {
            LibraryDepartment department = libraryDepartmentRepository.GetItem(new Guid(arrayString[4]));
            return new Book(new Guid(arrayString[0]), arrayString[1], arrayString[2], Convert.ToInt32(arrayString[3]), department);
        }
    }
}
