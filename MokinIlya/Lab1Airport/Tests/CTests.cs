using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Lab1Airport.Repository;
using Lab1Airport;

namespace Tests
{
    [TestFixture]
    public class CTests
    {
        [Test]
        public void TestBankAddGetUpdateDelete()
        {
            //Add-Get-Тест
            decimal? ammount = 2000;
            DateTime date = DateTime.Now;

            Bank expectedBank = new Bank();
            expectedBank.Ammount = ammount;
            expectedBank.Date = date;

            CBank bank = new CBank();
            bank.AddElement(expectedBank);
            var actualBank = bank.GetAll().Last();
            Assert.AreEqual(expectedBank, actualBank);

            //Update - Тест
            expectedBank = actualBank;
            expectedBank.Ammount = 3000;
            bank.UpdateElement(expectedBank);
            actualBank = bank.GetElement(expectedBank.CodePayment);
            Assert.AreEqual(expectedBank, actualBank);

            //Delete-Тест
            int expectedCount = bank.GetAll().Count() - 1;
            bank.DeleteElement(actualBank);
            int actualCount = bank.GetAll().Count();
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void TestPlainsAddGetUpdateDelete()
        {
            //Add-Get-Тест
            int numberOfSeats = 20;

            Plains expectedPlains = new Plains();
            expectedPlains.NumberOfSeats = numberOfSeats;

            CPlains plains = new CPlains();
            plains.AddElement(expectedPlains);
            var actualPLains = plains.GetAll().Last();
            Assert.AreEqual(expectedPlains, actualPLains);

            //Update - Тест
            expectedPlains = actualPLains;
            expectedPlains.NumberOfSeats = 30;
            plains.UpdateElement(expectedPlains);
            actualPLains = plains.GetElement(expectedPlains.CodePlane);
            Assert.AreEqual(expectedPlains, actualPLains);

            //Delete-Тест
            int expectedCount = plains.GetAll().Count() - 1;
            plains.DeleteElement(actualPLains);
            int actualCount = plains.GetAll().Count();
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void TestReisAddGetUpdateDelete()
        {
            //Add-Get-Тест
            DateTime date = DateTime.Now;
            Reis expectedReis = new Reis();
            expectedReis.Date = date;

            CReis reis = new CReis();
            reis.AddElement(expectedReis);
            var actualReis = reis.GetAll().Last();
            Assert.AreEqual(expectedReis, actualReis);

            //Update - Тест
            expectedReis = actualReis;
            expectedReis.Date = date.AddDays(2);
            reis.UpdateElement(expectedReis);
            actualReis = reis.GetElement(expectedReis.CodeReis);
            Assert.AreEqual(expectedReis, actualReis);

            //Delete-Тест
            int expectedCount = reis.GetAll().Count() - 1;
            reis.DeleteElement(actualReis);
            int actualCount = reis.GetAll().Count();
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void TestBasicReisAddGetUpdateDelete()
        {
            //Add-Get-Тест
            DateTime date = DateTime.Now;
            BasicReis expectedBasicReis = new BasicReis();
            expectedBasicReis.Date = date;

            CBasicReis basicReis = new CBasicReis();
            basicReis.AddElement(expectedBasicReis);
            var actualBasicReis = basicReis.GetAll().Last();
            Assert.AreEqual(expectedBasicReis, actualBasicReis);

            //Update - Тест
            expectedBasicReis = actualBasicReis;
            expectedBasicReis.Date = date.AddDays(2);
            basicReis.UpdateElement(expectedBasicReis);
            actualBasicReis = basicReis.GetElement(expectedBasicReis.CodeBasicReis);
            Assert.AreEqual(expectedBasicReis, actualBasicReis);

            //Delete-Тест
            int expectedCount = basicReis.GetAll().Count() - 1;
            basicReis.DeleteElement(actualBasicReis);
            int actualCount = basicReis.GetAll().Count();
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void TestClientsAddGetUpdateDelete()
        {
            //Add-Get-Тест
            bool bookOrBuy = true;
            Clients expectedClients = new Clients();
            expectedClients.BookOrBuy = bookOrBuy;

            CClients basicReis = new CClients();
            basicReis.AddElement(expectedClients);
            var actualClients = basicReis.GetAll().Last();
            Assert.AreEqual(expectedClients, actualClients);

            //Update - Тест
            expectedClients = actualClients;
            expectedClients.BookOrBuy = false;
            basicReis.UpdateElement(expectedClients);
            actualClients = basicReis.GetElement(expectedClients.CodeClient);
            Assert.AreEqual(expectedClients, actualClients);

            //Delete-Тест
            int expectedCount = basicReis.GetAll().Count() - 1;
            basicReis.DeleteElement(actualClients);
            int actualCount = basicReis.GetAll().Count();
            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}
