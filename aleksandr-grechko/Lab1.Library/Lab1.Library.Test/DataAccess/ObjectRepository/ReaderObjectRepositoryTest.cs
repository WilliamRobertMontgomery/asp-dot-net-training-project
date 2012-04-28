using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Lab1.Library.Entities;
using Lab1.Library.DataAccess;

namespace Lab1.Library.Test.DataAccess.ObjectRepository
{
    [TestFixture]
    public class ReaderObjectRepositoryTest
    {
        IRepository<Reader> readerRepository;
        Reader John, Alex, Pavel;

        public ReaderObjectRepositoryTest()
        {
            readerRepository = new ReaderObjectRepository();
            John = new Reader("John Doe", "Boston");
            Alex = new Reader("Alex Pupkin", "London");
            Pavel = new Reader("Павел Первый", "Брест");
        }

        [Test]
        public void EmptyRepositoryTest()
        {
            Assert.AreEqual(readerRepository.GetItems().Count(), 0);
        }

        [Test]
        public void SaveTest()
        {
            readerRepository.Save(John);
            Assert.AreEqual(readerRepository.GetItems().Count(), 1);
            readerRepository.Save(Alex);
            Assert.AreEqual(readerRepository.GetItems().Count(), 2);
            readerRepository.Save(Alex);
            Assert.AreEqual(readerRepository.GetItems().Count(), 2);
        }

        [Test]
        public void 



    }
}
