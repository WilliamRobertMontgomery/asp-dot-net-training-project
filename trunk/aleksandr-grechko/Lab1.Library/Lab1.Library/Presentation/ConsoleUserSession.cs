using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.Library.Entities;
using Lab1.Library.BusinessLogic;
using System.Resources;

namespace Lab1.Library.Presentation
{
	public class ConsoleUserSession
	{
		private Reader reader;

		private LibraryClass library;

		private ResourceManager rm;

		public ConsoleUserSession(LibraryClass library)
		{
			this.library = library;
						
			rm = ResourceManager.CreateFileBasedResourceManager("ConsoleResources", ".", null);
		}

		public void MainMenuView()
		{
			bool exit = false;
			do
			{
				Console.Clear();

                /*
                * AUTHOR: Mikalai Strylets
                * REVIEW: Do not hardcode strings or user interface resources
                * DETAILS: Storing your data in a resource file enables you to change the data without recompiling your entire app.
                 * It also enables you to store data in a single location, and eliminates the need to rely on hard-coded data
                 * that is stored in multiple locations. For details see http://msdn.microsoft.com/en-us/library/w7x1y988.aspx
                 * See also following MSDN sections which describes how to use resources in your applications
                 * http://msdn.microsoft.com/en-us/library/f45fce5x.aspx
                 * http://msdn.microsoft.com/en-us/library/9za7fxc7.aspx
                 * http://msdn.microsoft.com/en-us/library/7k989cfy%28v=vs.90%29.aspx
                */
				Console.WriteLine(rm.GetString("ReaderNameTitle"), (reader != null) ? reader.FullName : "Anonymous");
				Console.WriteLine(rm.GetString("MainMenu"));
				switch (GetMenuNumber(5))
				{
					case 1:
						GetBook(GetObjectFromListObjects(library.GetAllBooks()) as Book);
						break;
					case 2:
						LibraryDepartment department = GetObjectFromListObjects(library.GetDepartments()) as LibraryDepartment;
						if (department != null)
						{
							GetBook(GetObjectFromListObjects(library.GetBooksByDepartment(department)) as Book);
						}
						break;
					case 3:
						Console.Write(rm.GetString("AuthorNamePrompt"));
						GetBook(GetObjectFromListObjects(library.GetBooksByAuthor(Console.ReadLine())) as Book);
						break;
					case 4:
						Console.Write(rm.GetString("TitleBookPrompt"));
						GetBook(GetObjectFromListObjects(library.GetBooksByTitle(Console.ReadLine())) as Book);
						break;
					case 5:
						ReturnBook();
						break;
					case 0:
						exit = ExitSession();
						break;
				}
			}
			while (!exit);
		}

		private bool ExitSession()
		{
			if (reader == null)	return true;

			library.ExitReader(reader);
			reader = null;

			Console.WriteLine(rm.GetString("CountinueSessionQuestion"));
			if (GetMenuNumber(1) == 0) return true;

			return false;
		}

		private void GetBook(Book book)
		{
			if (book == null) return;
			if (reader == null && !Authorization()) return;
			Console.Clear();
			Console.WriteLine(rm.GetString("OrderBookTitle"), book);
			if (library.OrderBook(book, reader))
			{
				Console.WriteLine(rm.GetString("OrderSuccess"));
			}
			else
			{
				Console.WriteLine(rm.GetString("OrderWrong"));
			}
			Console.ReadLine();
		}

		private void ReturnBook()
		{
			if (reader == null && !Authorization()) return;
			Book book = GetObjectFromListObjects(library.GetBooksOrderedByReader(reader)) as Book;
			if (book != null) library.ReturnBook(book);
		}

		private bool Authorization()
		{
			if (reader != null) return true;
			Console.Clear();
			//Console.WriteLine("Авторизация\n");	rm.GetString("")
			Console.WriteLine(rm.GetString("AuthorizationTitle"));
			Console.Write(rm.GetString("AuthorizationPrompt"));
			string fullName = Console.ReadLine();
			reader = library.GetReader(fullName);
			if (reader == null)
			{
				Console.WriteLine(rm.GetString("ReaderNotFound"));
				Console.WriteLine(rm.GetString("AddNewReaderQuestion"));
				if (GetMenuNumber(1) == 0) return false;
				Console.Write(rm.GetString("AddressNewReaderPrompt"));
				reader = library.AddReader(fullName, Console.ReadLine());
			}
			if (!library.AuthorizationReader(reader))
			{
				Console.WriteLine(rm.GetString("AuthorizationError"), reader.FullName);
				Console.ReadLine();
				reader = null;
				return false;
			}
			return true;
		}

		private object GetObjectFromListObjects(IEnumerable<Object> objects)
		{
			Console.Clear();
			for (int i = 0; i <= objects.Count() - 1; i++)
				Console.WriteLine("{0}. {1}", i + 1, objects.ElementAt(i));
			Console.WriteLine(rm.GetString("Exit"));

			int index = GetMenuNumber(objects.Count());

			return (index != 0) ? objects.ElementAt(index - 1) : null;
		}

		private int GetMenuNumber(int max)
		{
			string input;
			int inputNumber;
			do
				input = Console.ReadLine();
			while (!Int32.TryParse(input, out inputNumber) || inputNumber < 0 || inputNumber > max);
			return inputNumber;
		}


	}
}
