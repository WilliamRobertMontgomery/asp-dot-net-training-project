using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.Library.Entities;
using System.IO;

namespace Lab1.Library.DataAccess
{
	public class OrderTextRepository : OrderRepository
	{

        private const string FileName = @"Text\Orders.txt";

        private const int RecordSize = 1024;

        private const int MaxRecordStringLength = (RecordSize - 2) / 2;
       
        public OrderTextRepository(ReaderRepository readerRepository, BookRepository bookRepository, 
			LibraryDepartmentRepository libraryDepartmentRepository, LibrarianRepository librarianRepository)
		{
			this.readerRepository = readerRepository;
			this.bookRepository = bookRepository;
			this.libraryDepartmentRepository = libraryDepartmentRepository;
			this.librarianRepository = librarianRepository;

            if (!Directory.GetParent(FileName).Exists) Directory.GetParent(FileName).Create();
            if (!File.Exists(FileName)) File.Create(FileName).Close();
        }

        public override Order GetItem(Guid id)
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

        public override IEnumerable<Order> GetItems()
        {
            using (BinaryReader binaryReader = new BinaryReader(File.Open(FileName, FileMode.Open), Encoding.Unicode))
            {
                while (binaryReader.PeekChar() != -1)
                {
                    yield return CreateItem(binaryReader.ReadString().Split('|'));
                }
            }
        }

        public override void Save(Order item)
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
                StringBuilder str = new StringBuilder( String.Join("|", item.Id.ToString(), item.Reader.Id.ToString(), item.Book.Id.ToString(), 
                    item.Department.Id.ToString(), item.TimeGetBook.ToString(),
                    item.LibrarianOpenOrder != null ? item.LibrarianOpenOrder.Id.ToString() : Guid.Empty.ToString(),
                    item.TimeReturnBook.ToString(),
                    item.LibrarianClosedOrder != null ? item.LibrarianClosedOrder.Id.ToString() : Guid.Empty.ToString(), 
                    item.Closed.ToString()));
                str.Append("|");
                str.Length = MaxRecordStringLength;
                binaryWriter.Write(str.ToString());
            }
            readerRepository.Save(item.Reader);
            bookRepository.Save(item.Book);
            if (item.LibrarianOpenOrder != null) librarianRepository.Save(item.LibrarianOpenOrder);
            if (item.LibrarianClosedOrder != null) librarianRepository.Save(item.LibrarianClosedOrder);
        }

        public override void Remove(Order item)
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

        public override IEnumerable<Order> GetOrdersByBook(Book book, bool closed)
        {
            using (BinaryReader binaryReader = new BinaryReader(File.Open(FileName, FileMode.Open), Encoding.Unicode))
            {
                while (binaryReader.PeekChar() != -1)
                {
                    string[] arrayString = binaryReader.ReadString().Split('|');
                    if ( arrayString[2] == book.Id.ToString() && Convert.ToBoolean(arrayString[8]) == closed )
                    {
                        yield return CreateItem(arrayString);
                    }
                }
            }
        }

        public override IEnumerable<Order> GetOrdersByReader(Reader reader, bool closed)
        {
            using (BinaryReader binaryReader = new BinaryReader(File.Open(FileName, FileMode.Open), Encoding.Unicode))
            {
                while (binaryReader.PeekChar() != -1)
                {
                    string[] arrayString = binaryReader.ReadString().Split('|');
                    if (arrayString[1] == reader.Id.ToString() && Convert.ToBoolean(arrayString[8]) == closed)
                    {
                        yield return CreateItem(arrayString);
                    }
                }
            }
        }

        public override IEnumerable<Order> GetOpenOrders()
        {
            using (BinaryReader binaryReader = new BinaryReader(File.Open(FileName, FileMode.Open), Encoding.Unicode))
            {
                while (binaryReader.PeekChar() != -1)
                {
                    string[] arrayString = binaryReader.ReadString().Split('|');
                    if (!Convert.ToBoolean(arrayString[8]))
                    {
                        yield return CreateItem(arrayString);
                    }
                }
            }
        }

        private Order CreateItem(string[] arrayString)
        {
            Reader reader = readerRepository.GetItem(new Guid(arrayString[1]));
            Book book = bookRepository.GetItem(new Guid(arrayString[2]));
            
            Order order =  new Order(new Guid(arrayString[0]), reader, book);

            order.TimeGetBook = Convert.ToDateTime(arrayString[4]);
            order.LibrarianOpenOrder = librarianRepository.GetItem(new Guid(arrayString[5]));
            order.TimeReturnBook = Convert.ToDateTime(arrayString[6]);
            order.LibrarianClosedOrder = librarianRepository.GetItem(new Guid(arrayString[7]));
            order.Closed = Convert.ToBoolean(arrayString[8]);

            return order;
        }

    }
}
