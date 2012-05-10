using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Lab1Airport;
using Lab1Airport.Entities;

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

            AccessToBank bank = new AccessToBank();
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
        public void TestPlanesAddGetUpdateDelete()
        {
            //Add-Get-Тест
            int numberOfSeats = 20;

            Planes expectedPlanes = new Planes();
            expectedPlanes.NumberOfSeats = numberOfSeats;

            AccessToPlanes Planes = new AccessToPlanes();
            Planes.AddElement(expectedPlanes);
            var actualPlanes = Planes.GetAll().Last();
            Assert.AreEqual(expectedPlanes, actualPlanes);

            //Update - Тест
            expectedPlanes = actualPlanes;
            expectedPlanes.NumberOfSeats = 30;
            Planes.UpdateElement(expectedPlanes);
            actualPlanes = Planes.GetElement(expectedPlanes.CodePlane);
            Assert.AreEqual(expectedPlanes, actualPlanes);

            //Delete-Тест
            int expectedCount = Planes.GetAll().Count() - 1;
            Planes.DeleteElement(actualPlanes);
            int actualCount = Planes.GetAll().Count();
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void TestReisAddGetUpdateDelete()
        {
            //Add-Get-Тест
            DateTime date = DateTime.Now;
            Reis expectedReis = new Reis();
            expectedReis.Date = date;

            AccessToReis reis = new AccessToReis();
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

            AccessToBasicReis basicReis = new AccessToBasicReis();
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

            AccessToClients basicReis = new AccessToClients();
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
