using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.Library.Entities;
using Lab1.Library.DataAccess;
using Lab1.Library.BusinessLogic;
using Lab1.Library.Presentation;

namespace Lab1.Library
{
	class Program
	{
		static private LibraryClass library;

		static private ConsoleUserSession userSession;

		static void InitData(Repository repository)
		{
			LibraryDepartment abonement = new LibraryDepartment("Абонемент", true);
			LibraryDepartment readingRoom = new LibraryDepartment("Читальный зал", false);
			repository.LibraryDepartmentRepository.Save(abonement);
			repository.LibraryDepartmentRepository.Save(readingRoom);

			repository.LibrarianRepository.Save(new Librarian("Мария Иванова", abonement));
			repository.LibrarianRepository.Save(new Librarian("Татьяна Петрова", readingRoom));

			repository.ReaderRepository.Save(new Reader("Иван Иванов", "Брест"));
			repository.ReaderRepository.Save(new Reader("Петр Петров", "Брест"));
			repository.ReaderRepository.Save(new Reader("Сидор Сидоров", "Брест"));

			repository.BookRepository.Save(new Book("Бен Ватсон", "С# 4.0 на примерах", 2000, abonement));
			repository.BookRepository.Save(new Book("Кристиан Нейгел", "C# 4.0 и платформа .NET 4", 2001, abonement));
			repository.BookRepository.Save(new Book("Михаил Фленов", "Библия C#", 2002, abonement));
			repository.BookRepository.Save(new Book("Чарльз Петцольд", "Программирование в тональности C#", 2003, abonement));
			repository.BookRepository.Save(new Book("Герберт Шилдт", "C# 4.0 полное руководство", 2004, abonement));
			repository.BookRepository.Save(new Book("Трей Нэш", "C# 2010. Ускоренный курс ", 2005, readingRoom));
			repository.BookRepository.Save(new Book("Мэтью Мак-Дональд", "Microsoft ASP.NET 3.5 с примерами", 2006, readingRoom));
			repository.BookRepository.Save(new Book("Чарльз Петцольд", "Программирование с использованием Windows Forms", 2007, readingRoom));
			repository.BookRepository.Save(new Book("Фаронов В.В.", "Программирование на языке С#", 2008, readingRoom));
			repository.BookRepository.Save(new Book("Либерти Дж.", "Программирование на C#", 2009, readingRoom));
		}

		static void InitApplication()
		{
			//Repository repository = new Repository(new ObjectRepositoryFactory());
			Repository repository = new Repository(new TextRepositoryFactory());
			
			//InitData(repository);

			library = new LibraryClass(repository);

			userSession = new ConsoleUserSession(library);
		}

		static void Main(string[] args)
		{
			InitApplication();

			userSession.MainMenuView();

		}
	}
}
