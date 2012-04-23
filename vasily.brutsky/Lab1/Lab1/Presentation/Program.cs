using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.BusinessLogic;
using Lab1.DataAccess;
using Lab1.Entities;
using System.IO;
namespace Lab1
{
   

    class Program
    {

        static void AutoFilling()
        {

            Product[] product = new Product[10];
            Client[] client = new Client[10];
            Manager[] manager = new Manager[10];
            
            StreamWriter clientRefresh = new StreamWriter("C:\\Clients.txt");
            clientRefresh.Flush();
            clientRefresh.Close();

            StreamWriter productRefresh = new StreamWriter("C:\\Products.txt");
            productRefresh.Flush();
            productRefresh.Close();

            StreamWriter managerRefresh = new StreamWriter("C:\\Managers.txt");
            managerRefresh.Flush();
            managerRefresh.Close();

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



            
            for (int  i=0 ; i<=9 ; i++)
            {
                _clientRepository.Save(client[i]);
                _productRepository.Save(product[i]);
                _managerRepository.Save(manager[i]);
            }

        }

        static void Main(string[] args)
        {
            AutoFilling();

            while (true)
            {

                IRepository<Client> _clientRepository = new ClientRepository();
                IRepository<Product> _productRepository = new ProductRepository();
                IRepository<Manager> _managerRepository = new ManagerRepository();
                IEnumerable<Client> clientRepository = _clientRepository.GetItems();
                IEnumerable<Product> productRepository = _productRepository.GetItems();
                IEnumerable<Manager> managerRepository = _managerRepository.GetItems();
                Console.Write("The assortment of products \n");

                Realtor.PrintAssortment(productRepository);

                int countOfProducts = _productRepository.GetItems().Count();
                int countOfClients = _clientRepository.GetItems().Count();
                int countOfManagers = _managerRepository.GetItems().Count();


                Console.WriteLine("What do you want to buy?");
                int id = 0;

                while (true)
                {
                    Realtor.ChooseProduct(ref id);
                    Realtor.ChooseManager(_managerRepository);

                    if (id < 0 || id > countOfProducts)
                    {
                        Console.WriteLine("Incorrect number. Try again. A number of products is: {0} ", countOfProducts);
                    }
                    else
                    {
                        break;
                    }
                }
                
                if (!Realtor.IsAvailable(_productRepository,id)) 
                {
                    Console.WriteLine("Sorry. This product is saled");
                }

                else
                {

                    Console.WriteLine("Enter your Name");
                    string name = Console.ReadLine();
                   

                    if (!Realtor.IsNewClient(clientRepository,name))
                    {
                        Console.WriteLine("You are new client. You will be saved in our database");
                        countOfClients += 1;
                        Realtor.RememberClient(_clientRepository, countOfClients, name);

                    }

                    Realtor.Deal(_productRepository, id);

                }

                Console.ReadKey();
               if (!Realtor.Proceed())
                
                    break;
                else Console.Clear();
            }

        }
    }
}
