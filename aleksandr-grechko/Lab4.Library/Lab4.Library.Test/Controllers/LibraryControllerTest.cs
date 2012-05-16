using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Lab4.Library.Controllers;
using System.Web.Mvc;
using Lab4.Library.BusinessLogic;
using Moq;
using Lab4.Library.Models;
using System.Web;
using System.Security.Principal;
using System.Web.Routing;


namespace Lab4.Library.Test.Controllers
{
	[TestFixture]
	public class LibraryControllerTest
	{
		private LibraryController libraryController;

		private Mock<ILibraryClass> library;

		[SetUp]
		public void Init()
		{
			library = new Mock<ILibraryClass>();
			libraryController = new LibraryController(library.Object);
		}

		[Test]
		public void All_Test()
		{
			library.Setup(lib => lib.GetAllBooks()).Returns(new List<Book>());

			var result = libraryController.All() as ViewResult;
			var model = result.ViewData.Model as IEnumerable<Book>;

			Assert.IsNotNull(result);
			Assert.IsNotNull(model);
			Assert.AreEqual("ListBooks", result.ViewName);
			Assert.AreEqual("Все книги", result.ViewData["Title"]);
		}

		[Test]
		public void Departments_Test()
		{
			library.Setup(lib => lib.GetDepartments()).Returns(new List<LibraryDepartment>());

			var result = libraryController.Departments() as ViewResult;
			var model = result.ViewData.Model as IEnumerable<LibraryDepartment>;

			Assert.IsNotNull(result);
			Assert.IsNotNull(model);
		}

		[Test]
		public void Department_Not_Exists_Test()
		{
			library.Setup(lib => lib.GetDepartments()).Returns(new List<LibraryDepartment>());

			var result = libraryController.Department(Guid.Empty) as RedirectToRouteResult;

			Assert.IsNotNull(result);
			Assert.AreEqual("Departments", result.RouteValues["Action"]);
		}

		[Test]
		public void Department_Exists_Test()
		{
			var listDepartments = new List<LibraryDepartment>();
			var department = new LibraryDepartment(Guid.Empty, "Абонемент", true);
			listDepartments.Add(department);
			library.Setup(lib => lib.GetDepartments()).Returns(listDepartments);

			var result = libraryController.Department(Guid.Empty) as ViewResult;

			library.Verify(lib => lib.GetBooksByDepartment(department));
			Assert.IsNotNull(result);
			Assert.AreEqual(department.Name, result.ViewData["Title"]);
			Assert.AreEqual("ListBooks", result.ViewName);
		}

		[Test]
		public void Search_Test()
		{
			var result = libraryController.Search() as ViewResult;

			Assert.IsNotNull(result);
		}

		[Test]
		public void Search_String_Is_Empty_Test()
		{
			FormCollection form = new FormCollection();
			form["SearchText"] = String.Empty;

			var result = libraryController.Search(form) as ViewResult;

			Assert.IsFalse(libraryController.ModelState.IsValid);
			Assert.IsNotNull(result);
		}

		[Test]
		public void Search_Author_Test()
		{
			FormCollection form = new FormCollection();
			form["SearchText"] = "Name";
			form["SearchBy"] = "author";

			library.Setup(lib => lib.GetBooksByAuthor(form["SearchText"])).Returns(new List<Book>());

			var result = libraryController.Search(form) as ViewResult;
			var model = result.ViewData.Model as IEnumerable<Book>;

			Assert.IsNotNull(result);
			Assert.IsNotNull(model);
			Assert.AreEqual("Поиск по автору - " + form["SearchText"], result.ViewData["Title"]);
			Assert.AreEqual("ListBooks", result.ViewName);
		}

		[Test]
		public void Search_Title_Test()
		{
			FormCollection form = new FormCollection();
			form["SearchText"] = "Title";
			form["SearchBy"] = "title";

			library.Setup(lib => lib.GetBooksByTitle(form["SearchText"])).Returns(new List<Book>());

			var result = libraryController.Search(form) as ViewResult;
			var model = result.ViewData.Model as IEnumerable<Book>;

			Assert.IsNotNull(result);
			Assert.IsNotNull(model);
			Assert.AreEqual("Поиск по названию - " + form["SearchText"], result.ViewData["Title"]);
			Assert.AreEqual("ListBooks", result.ViewName);
		}

		[Test]
		public void Order_Success_Test()
		{
			var listBooks = new List<Book>();
			var book = new Book(Guid.Empty, "Name", "Title", 2000, new LibraryDepartment());
			listBooks.Add(book);
			library.Setup(lib => lib.GetAllBooks()).Returns(listBooks);

			var reader = new Reader("Name", "Address");
			library.Setup(lib => lib.GetReader(It.IsAny<string>())).Returns(reader);

			library.Setup(lib => lib.OrderBook(book, reader)).Returns(true);

			libraryController.ControllerContext = new ControllerContext()
			{
				Controller = libraryController,
				RequestContext = new RequestContext(new MockHttpContext(), new RouteData())
			};
			var result = libraryController.Order(Guid.Empty) as ViewResult;

			Assert.IsNotNull(result);
			Assert.AreEqual("Читайте на здоровье!", result.ViewData["Message"]);
		}

		[Test]
		public void Order_If_Book_Already_Ordered_Test()
		{
			var listBooks = new List<Book>();
			var book = new Book(Guid.Empty, "Name", "Title", 2000, new LibraryDepartment());
			listBooks.Add(book);
			library.Setup(lib => lib.GetAllBooks()).Returns(listBooks);

			var reader = new Reader("Name", "Address");
			library.Setup(lib => lib.GetReader(It.IsAny<string>())).Returns(reader);

			library.Setup(lib => lib.OrderBook(book, reader)).Returns(false);

			libraryController.ControllerContext = new ControllerContext()
			{
				Controller = libraryController,
				RequestContext = new RequestContext(new MockHttpContext(), new RouteData())
			};
			var result = libraryController.Order(Guid.Empty) as ViewResult;

			Assert.IsNotNull(result);
			Assert.AreEqual("Книга уже была выдана.", result.ViewData["Message"]);
		}

		[Test]
		public void Order_If_Book_Not_Exists_Test()
		{
			library.Setup(lib => lib.GetAllBooks()).Returns(new List<Book>());

			library.Setup(lib => lib.GetReader(It.IsAny<string>())).Returns(new Reader("Name", "Address"));

			libraryController.ControllerContext = new ControllerContext()
			{
				Controller = libraryController,
				RequestContext = new RequestContext(new MockHttpContext(), new RouteData())
			};
			var result = libraryController.Order(Guid.Empty) as RedirectToRouteResult;

			Assert.IsNotNull(result);
			Assert.AreEqual("Home", result.RouteValues["Controller"]);
			Assert.AreEqual("Index", result.RouteValues["Action"]);
		}

		[Test]
		public void Order_If_Reader_Not_Exists_Test()
		{
			var listBooks = new List<Book>();
			listBooks.Add(new Book(Guid.Empty, "Name", "Title", 2000, new LibraryDepartment()));
			library.Setup(lib => lib.GetAllBooks()).Returns(listBooks);

			library.Setup(lib => lib.GetReader(It.IsAny<string>())).Returns(null as Reader);

			libraryController.ControllerContext = new ControllerContext()
			{
				Controller = libraryController,
				RequestContext = new RequestContext(new MockHttpContext(), new RouteData())
			};
			var result = libraryController.Order(Guid.Empty) as RedirectToRouteResult;

			Assert.IsNotNull(result);
			Assert.AreEqual("Home", result.RouteValues["Controller"]);
			Assert.AreEqual("Index", result.RouteValues["Action"]);
		}

		[Test]
		public void ReturnList_If_Reader_Not_Exists_Test()
		{
			library.Setup(lib => lib.GetReader(It.IsAny<string>())).Returns(null as Reader);

			libraryController.ControllerContext = new ControllerContext()
			{
				Controller = libraryController,
				RequestContext = new RequestContext(new MockHttpContext(), new RouteData())
			};
			var result = libraryController.ReturnList() as RedirectToRouteResult;

			Assert.IsNotNull(result);
			Assert.AreEqual("Home", result.RouteValues["Controller"]);
			Assert.AreEqual("Index", result.RouteValues["Action"]);
		}


		[Test]
		public void ReturnList_If_Reader_Exists_Test()
		{
			library.Setup(lib => lib.GetReader(It.IsAny<string>())).Returns(new Reader("Name", "Address"));
			library.Setup(lib => lib.GetBooksOrderedByReader(It.IsAny<Reader>())).Returns(new List<Book>());

			libraryController.ControllerContext = new ControllerContext()
			{
				Controller = libraryController,
				RequestContext = new RequestContext(new MockHttpContext(), new RouteData())
			};
			var result = libraryController.ReturnList() as ViewResult;
			var model = result.ViewData.Model as IEnumerable<Book>;

			Assert.IsNotNull(result);
			Assert.IsNotNull(model);
		}

		[Test]
		public void Return_If_Book_Not_Exists_Test()
		{
			library.Setup(lib => lib.GetAllBooks()).Returns(new List<Book>());

			var result = libraryController.Return(Guid.Empty) as RedirectToRouteResult;

			Assert.IsNotNull(result);
			Assert.AreEqual("ReturnList", result.RouteValues["Action"]);
		}

		[Test]
		public void Return_If_Book_Exists_Test()
		{
			var listBooks = new List<Book>();
			var book = new Book(Guid.Empty, "Name", "Title", 2000, null);
			listBooks.Add(book);
			library.Setup(lib => lib.GetAllBooks()).Returns(listBooks);

			var result = libraryController.Return(Guid.Empty) as RedirectToRouteResult;

			library.Verify(lib => lib.ReturnBook(book));
			Assert.IsNotNull(result);
			Assert.AreEqual("ReturnList", result.RouteValues["Action"]);
		}
	}
}
