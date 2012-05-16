using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.Models.DataAccess
{
    public static class ClearDatabase
    {
        public static void Clear()
        {
            IRepository<Client> _clientRepository = new ClientRepository();
            IRepository<Product> _productRepository = new ProductRepository();
            IRepository<Manager> _managerRepository = new ManagerRepository();

            IEnumerable<Client> clientRepository = _clientRepository.GetItems();
            IEnumerable<Product> productRepository = _productRepository.GetItems();
            IEnumerable<Manager> managerRepository = _managerRepository.GetItems();

            foreach (var item in clientRepository)
            {
                _clientRepository.Remove(item);
            }

            foreach (var item in productRepository)
            {
                _productRepository.Remove(item);
            }

            foreach (var item in managerRepository)
            {
                _managerRepository.Remove(item);
            }
        }
    }
}