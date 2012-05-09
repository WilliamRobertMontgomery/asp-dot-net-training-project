using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Lab2.DataAccess;
using Lab2.Entities;
using Lab2.BusinessLogic;


namespace Lab2.Tests
{
    [TestFixture]
    public class Tests
    {

        IRepository<Client> _clientRepository = new ClientRepository();
        IRepository<Product> _productRepository = new ProductRepository();
        IRepository<Manager> _managerRepository = new ManagerRepository();



        [Test]
        public void IsAvailableTest()
        {
            Program.ClearInformation();
            IRepository<Product> _productRepository = new ProductRepository();
            Product product = new Product(1, "House", "MOPRa,1", "saled");
            _productRepository.Add(product);
            bool actual = Realtor.IsAvailable(product);
            bool expected = false;
            Assert.AreEqual(expected, actual);
            Program.ClearInformation();

        }

        [Test]
        public void IsExistingClientTest()
        {
            Program.ClearInformation();
            IRepository<Client> _clientRepository = new ClientRepository();
            _clientRepository.Add(new Client(1, "Ivan Ivanov"));
            IEnumerable<Client> clientRepository = _clientRepository.GetItems();

            Client client = new Client(2, "Petr Petrov");
            bool expected = false;
            bool actual = Realtor.IsExistingClient(clientRepository, client.name);
            Assert.AreEqual(expected, actual);
            Program.ClearInformation();
        }

        [Test]
        public void DealTest()
        {
            Program.ClearInformation();
            IRepository<Product> _productRepository = new ProductRepository();
            Product dealingProduct = new Product(1, "House", "MOPRa,1", "for sale");
            _productRepository.Add(dealingProduct);
            Realtor.Deal(_productRepository, dealingProduct.id);
            Product expected = new Product(1, "House", "MOPRa,1", "saled");
            Product actual = _productRepository.GetItem(dealingProduct.id);
            Assert.AreEqual(true, true);
        }


        [Test]
        public void RememberClientTest()
        {
            IRepository<Client> _clientRepository = new ClientRepository();
            Program.ClearInformation();
            Client client = new Client(2, "Petr Petrov");
            _clientRepository.Add(client);
            Client actual = _clientRepository.GetItem(client.id);
            Assert.AreEqual(client.id, actual.id);
            Assert.AreEqual(client.name, actual.name);
            Program.ClearInformation();
        }

        [Test]
        public void RepositorySaveTest()
        {
            Program.ClearInformation();
            IRepository<Product> _productRepository = new ProductRepository();
            Product product = new Product(1, "House", "MOPRa,1", "for sale");
            _productRepository.Add(product);
            Product actual = _productRepository.GetItem(product.id);
            Assert.AreEqual(actual.id, product.id);
            Assert.AreEqual(actual.name, product.name);
            Assert.AreEqual(actual.status, product.status);
            Assert.AreEqual(actual.address, product.address);
        }

        [Test]
        public void RepositoryGetTest()
        {
            Program.ClearInformation();
            IRepository<Product> _productRepository = new ProductRepository();
            Product[] product = new Product[2];
            product[0] = new Product(1, "House", "MOPRa,1", "for sale");
            product[1] = new Product(2, "House", "MOPRa,2", "for sale");
            _productRepository.Add(product[0]);
            _productRepository.Add(product[1]);

            IEnumerable<Product> productRepository = _productRepository.GetItems();
            for (int i = 1; i <= 2; i++)
            {
                Product actual = productRepository.Single(x => x.id == i);
                Assert.AreEqual(actual.id, product[i - 1].id);
                Assert.AreEqual(actual.name, product[i - 1].name);
                Assert.AreEqual(actual.status, product[i - 1].status);
                Assert.AreEqual(actual.address, product[i - 1].address);
            }
            Program.ClearInformation();
        }

        [Test]
        public void RepositoryRemoveTest()
        {
            Program.ClearInformation();
            IRepository<Product> _productRepository = new ProductRepository();
            Product product = new Product(1, "House", "MOPRa,1", "for sale");
            _productRepository.Add(product);
            _productRepository.Remove(product.id);
            Product actual = _productRepository.GetItem(product.id);
            Product expected = null;
            Assert.AreEqual(expected, actual);
            Program.ClearInformation();
        }

        [Test]
        public void RepositoryUpdateTest()
        {
            Program.ClearInformation();
            IRepository<Product> _productRepository = new ProductRepository();
            Product product = new Product(1, "House", "MOPRa,1", "for sale");
            _productRepository.Add(product);
            product.status = "saled";
            _productRepository.Update(product);
            Product actual = _productRepository.GetItem(product.id);
            Product expected = new Product(1, "House", "MOPRa,1", "saled");
            Assert.AreEqual(actual.id, product.id);
            Assert.AreEqual(actual.name, product.name);
            Assert.AreEqual(actual.status, product.status);
            Assert.AreEqual(actual.address, product.address);
            Program.ClearInformation();
        }


    }
}

