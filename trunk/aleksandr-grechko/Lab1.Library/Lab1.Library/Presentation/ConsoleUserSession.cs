using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.Library.Entities;
using Lab1.Library.BusinessLogic;

namespace Lab1.Library.Presentation
{
	public class ConsoleUserSession
	{
		private Reader reader;

		private LibraryClass library;

		public ConsoleUserSession(LibraryClass library)
		{
			this.library = library;
		}

		public void MainMenuView()
		{
			bool exit = false;
			do
			{
				Console.Clear();
				Console.WriteLine("Пользователь - {0}\n", (reader != null) ? reader.FullName : "Anonymous" );
				Console.WriteLine("Выбор книги\n1. Все книги\n2. Список по отделам\n3. Поиск по автору\n4. Поиск по названию\n\n5. Вернуть книгу\n\n0. Выйти\n");
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
						Console.Write("Введите имя автора: ");
						GetBook(GetObjectFromListObjects(library.GetBooksByAuthor(Console.ReadLine())) as Book);
						break;
					case 4:
						Console.Write("Введите название книги: ");
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

			Console.WriteLine("Хотите продолжить работу ( Yes - 1 / No - 0): ");
			if (GetMenuNumber(1) == 0) return true;

			return false;
		}

		private void GetBook(Book book)
		{
			if (book == null) return;
			if (reader == null && !Authorization()) return;
			Console.Clear();
			Console.WriteLine("Заказ книги - {0}\n", book);
			if (library.OrderBook(book, reader))
			{
				Console.WriteLine("Читайте на здоровье!");
			}
			else
			{
				Console.WriteLine("Выбраная вами книга уже выдана.");
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
			Console.WriteLine("Авторизация\n");
			Console.Write("Введите полное имя пользователя: ");
			string fullName = Console.ReadLine();
			reader = library.GetReader(fullName);
			if (reader == null)
			{
				Console.WriteLine("Пользователь с таким именем не найден.\nХотите добавить нового пользователя ( Yes - 1 / No - 0): ");
				if (GetMenuNumber(1) == 0) return false;
				Console.Write("Введите адрес нового пользователя: ");
				reader = library.AddReader(fullName, Console.ReadLine());
			}
			if (!library.AuthorizationReader(reader))
			{
				Console.WriteLine("Пользователь {0} уже работает в системе.", reader.FullName);
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
			Console.WriteLine("\n0. Выйти\n");

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
