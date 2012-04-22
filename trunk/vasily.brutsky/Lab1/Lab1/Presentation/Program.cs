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

                Console.Write("The available products \n");
                foreach (var item in productRepository)
                {
                    Console.WriteLine("ID = {0}; Name = {1}; Address = {2}, Status = {3} ", item.id, item.name, item.address, item.status);
                }
                Console.WriteLine();

                int countOfProducts = _productRepository.GetItems().Count();
                int countOfClients = _clientRepository.GetItems().Count();
                int countOfManagers = _managerRepository.GetItems().Count();


                Console.WriteLine("What do you want to buy?");
                int id = 0;

                while (true)
                {
                    Console.WriteLine("Press the number of product");
                    while (true)
                    {

                        try
                        {
                            id = Convert.ToInt32(Console.ReadLine());
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Invalid enter. ENTER A NUMBER, PLEASE!");
                        }

                    }

                    Random rand = new Random();
                   
                    Console.WriteLine("Your manager will be {0}", _managerRepository.GetItem(rand.Next(1,10)).name);

                    if (id < 0 || id > countOfProducts)
                    {
                        Console.WriteLine("Incorrect number. Try again. A number of products is: {0} ", countOfProducts);
                    }
                    else
                    {
                        break;
                    }
                }

                if (_productRepository.GetItem(id).status == "saled")
                {
                    Console.WriteLine("Sorry. This product is saled", countOfProducts);
                }

                else
                {
                    Console.WriteLine("Enter your Name");
                    string name = Console.ReadLine();
                    bool flag = false;

                    foreach (var item in clientRepository)
                    {

                        if (item.name == name)
                        {
                            flag = true;
                            break;
                        }

                    }

                    if (!flag)
                    {
                        Console.WriteLine("You are new client. You will be saved in our database");
                        countOfClients += 1;
                        Client newClient = new Client(countOfClients, name);
                        _clientRepository.Save(newClient);

                    }

                    Console.WriteLine("Consratulations! You have bought the product {0} on address {1}", _productRepository.GetItem(id).name, _productRepository.GetItem(id).address);
                    Product saledProduct = new Product(id, _productRepository.GetItem(id).name, _productRepository.GetItem(id).address, "saled");

                    _productRepository.Update(saledProduct);

                }

                Console.ReadKey();
                string answer=null;

                Console.WriteLine("Would you like to buy anything else? Press Y (y) for 'yes' or N (n) for 'no'");
                while (true)
                {

                    try
                    {
                         answer = Console.ReadLine();
                        if (answer == "y" || answer == "Y" || answer == "N" || answer == "n")
                        {
                            break;
                        }
                        else throw new NotImplementedException();
                    }
                    catch
                    {
                        Console.WriteLine("Invalid answer");
                    }
                }

                if (answer == "N" || answer == "n")
                    break;
                else Console.Clear();
            }

        }
    }
}
