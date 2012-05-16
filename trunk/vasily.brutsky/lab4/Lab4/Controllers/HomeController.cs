using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Lab4.Models;
using Lab4.Models.DataAccess;

namespace Lab4.Controllers
{
    public class HomeController : Controller
    {
        public static void AutoFilling()
        {
            Product[] product = new Product[10];
            Client[] client = new Client[10];
            Manager[] manager = new Manager[10];

            product[0] = new Product(1, "House", "Moskovskaya, 320", "for sale");
            product[1] = new Product(2, "Office", "MOPRa, 30", "for sale");
            product[2] = new Product(3, "House", "Belorusskaya, 10", "for sale");
            product[3] = new Product(4, "Bar", "MOPRa, 3", "for sale");
            product[4] = new Product(5, "House", "Leningradskaya, 35", "for sale");
            product[5] = new Product(6, "Cafe", "Molodogvardeiskaya, 70", "for sale");
            product[6] = new Product(7, "House", "Moskovskaya, 30", "for sale");
            product[7] = new Product(8, "Club", "Zelenaya, 11", "for sale");
            product[8] = new Product(9, "House", "Lugivaja, 11", "for sale");
            product[9] = new Product(10, "Pizzeria", "Pionerskaya, 4", "for sale");

            client[0] = new Client(1, "Fedor Dvinyatin");
            client[1] = new Client(2, "Alexei Volkov");
            client[2] = new Client(3, "Ivan Ivanov");
            client[3] = new Client(4, "Petr Bojko");
            client[4] = new Client(5, "Egor Valedinsky");
            client[5] = new Client(6, "Alexander Evtuh");
            client[6] = new Client(7, "Alexei Lohnitsky");
            client[7] = new Client(8, "Mokin Alexander");
            client[8] = new Client(9, "Pavlovets Sergey");
            client[9] = new Client(10, "Igor Pujko");

            manager[0] = new Manager(1, "Viktor Oniskevich");
            manager[1] = new Manager(2, "Petr Glinskij");
            manager[2] = new Manager(3, "Fedor Yakubuk");
            manager[3] = new Manager(4, "Vasily Sapon");
            manager[4] = new Manager(5, "Igor Ivanovskiy");
            manager[5] = new Manager(6, "Alexander Dubrovsky");
            manager[6] = new Manager(7, "Olga Golub");
            manager[7] = new Manager(8, "Egor Pirozhkov");
            manager[8] = new Manager(9, "Boris Zhukovich");
            manager[9] = new Manager(10, "Igor Stepanchuk");

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

            for (int i = 0; i <= 9; i++)
            {
                _clientRepository.Add(client[i]);
                _productRepository.Add(product[i]);
                _managerRepository.Add(manager[i]);
            }

        }
      
        public ActionResult Index()
        {
            AutoFilling();
            IRepository<Product> _productRepository = new ProductRepository();
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            return View();
        }

        public ActionResult Shop()
        {
            IRepository<Product> _productRepository = new ProductRepository();
            return View(_productRepository.GetItems());
        }

        public ActionResult Buy(Product product)
        {
            IRepository<Product> _productRepository = new ProductRepository();
            Product buyingProduct = _productRepository.GetItem(product.id);
            if (buyingProduct.status == "saled")
            {
                return RedirectToAction("ErrorOfSaledProduct");
            }
            else
            {
                buyingProduct.status = "saled";
                _productRepository.Update(buyingProduct);
                return RedirectToAction("Shop");
            }
        }

        public ActionResult ChooseManager()
        {
            IRepository<Manager> _managerRepository = new ManagerRepository();
            List<Manager> Managers = _managerRepository.GetItems().ToList();
            List<string> managerList = new List<String>();
            foreach (var item in Managers)
            {
                managerList.Add(item.name);
            }
            ViewData["ManagerList"] = managerList;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ChooseManager(ChooseManagerModel man)
        {
            return RedirectToAction("Shop", "Home");
        }
        public ActionResult ErrorOfSaledProduct()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
    }
}
