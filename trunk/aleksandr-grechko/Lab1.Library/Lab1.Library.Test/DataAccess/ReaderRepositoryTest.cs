using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Lab1.Library.Entities;
using Lab1.Library.DataAccess;

namespace Lab1.Library.Test.DataAccess
{
    [TestFixture(typeof(ObjectRepositoryFactory))]
    [TestFixture(typeof(TextRepositoryFactory))]
	[TestFixture(typeof(XMLRepositoryFactory))]
    public class ReaderRepositoryTest<T>
        where T : IRepositoryFactory, new()
	{
        IRepositoryFactory repositoryFactory;
		ReaderRepository readerRepository;
		Reader reader1, reader2;
		int countItems;

		public ReaderRepositoryTest()
		{
            repositoryFactory = new T();
            readerRepository = repositoryFactory.CreateReaderRepository();
			countItems = readerRepository.GetItems().Count();
			reader1 = new Reader("John Doe", "Boston");
			reader2 = new Reader("Alex Pupkin", "London");
		}

		[Test]
		public void SaveTest()
		{
			readerRepository.Save(reader1);
			Assert.AreEqual(readerRepository.GetItems().Count(), countItems + 1);
			readerRepository.Save(reader2);
			Assert.AreEqual(readerRepository.GetItems().Count(), countItems + 2);
			readerRepository.Save(reader2);
			Assert.AreEqual(readerRepository.GetItems().Count(), countItems + 2);
			readerRepository.Remove(reader2);
			readerRepository.Remove(reader1);
		}

		[Test]
		public void RemoveTest()
		{
			readerRepository.Save(reader1);
			readerRepository.Save(reader2);
			Assert.AreEqual(readerRepository.GetItems().Count(), countItems + 2);
			readerRepository.Remove(reader2);
			Assert.AreEqual(readerRepository.GetItems().Count(), countItems + 1);
			readerRepository.Remove(reader1.Id);
			Assert.AreEqual(readerRepository.GetItems().Count(), countItems);
			readerRepository.Remove(reader1);
			Assert.AreEqual(readerRepository.GetItems().Count(), countItems);
		}


		[Test]
		public void GetItemTest()
		{
			readerRepository.Save(reader1);
			readerRepository.Save(reader2);
			Reader r = readerRepository.GetItem(reader1.Id);
			Assert.IsNotNull(r);
			Assert.AreEqual(r, reader1);
			Assert.IsNotNull(readerRepository.GetItem(reader2.Id));
			Assert.IsNull(readerRepository.GetItem(new Reader("", "").Id));
			readerRepository.Remove(reader1);
			readerRepository.Remove(reader2);
		}

		[Test]
		public void UpdateTest()
		{
			readerRepository.Save(reader1);
			Assert.AreEqual(reader1, readerRepository.GetItem(reader1.Id));
			Reader r = new Reader(reader1.Id, reader1.FullName, "Minsk");
			readerRepository.Save(r);
			Assert.AreEqual(r, readerRepository.GetItem(r.Id));
			Assert.AreEqual(readerRepository.GetItem(reader1.Id), readerRepository.GetItem(r.Id));
			readerRepository.Remove(r);
		}

		[Test]
		public void GetItemsTest()
		{
			readerRepository.Save(reader1);
			readerRepository.Save(reader2);
			Assert.AreEqual(readerRepository.GetItems().Count(), countItems + 2);
			IEnumerable<Reader> readers = readerRepository.GetItems();
			Assert.IsNotNull(readers.SingleOrDefault(r => r.Id == reader1.Id));
			Assert.IsNotNull(readers.SingleOrDefault(r => r.Id == reader2.Id));
			readerRepository.Remove(reader1);
			readerRepository.Remove(reader2);
			Assert.AreEqual(readerRepository.GetItems().Count(), countItems);
		}

		[Test]
		public void GetReadersByName()
		{
			readerRepository.Save(reader1);
			readerRepository.Save(reader2);
			IEnumerable<Reader> readers = readerRepository.GetReadersByName("John Doe", true);
			Assert.AreEqual(1, readers.Count());
            Assert.AreEqual(reader1, readers.First());
			readers = readerRepository.GetReadersByName("n", false);
            Assert.AreEqual(2, readers.Count());
			Assert.IsNotNull(readers.SingleOrDefault(r => r.Id == reader1.Id));
			Assert.IsNotNull(readers.SingleOrDefault(r => r.Id == reader2.Id));
			readerRepository.Remove(reader1);
			readerRepository.Remove(reader2);
		}

	}
}
