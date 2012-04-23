using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.Entities;
using Lab1.DataAccess;

namespace Lab1.BusinessLogic
{
    public static class Realtor
    {
        public static bool IsAvailable(IRepository<Product> product, int id)
        {

            if (product.GetItem(id).status == "saled")
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public static bool IsNewClient(IEnumerable<Client> client, string name)
        {
            bool flag = false;

            foreach (var item in client)
            {
                if (item.name == name)
                {
                    flag = true;
                    
                }
            }
            if (flag)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Deal(IRepository<Product> product, int id)
        {
            Console.WriteLine("Consratulations! You have bought the product {0} on address {1}", product.GetItem(id).name, product.GetItem(id).address);
            Product saledProduct = new Product(id, product.GetItem(id).name, product.GetItem(id).address, "saled");
            product.Update(saledProduct);
        }

        public static bool Proceed()
        {
            string answer = null;

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

                if (answer == "y" || answer == "Y")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            
    
        }

        public static void PrintAssortment(IEnumerable<Product> productRepository)
        {
            foreach (var item in productRepository)
            {
                Console.WriteLine("ID = {0}; Name = {1}; Address = {2}, Status = {3} ", item.id, item.name, item.address, item.status);
            }
            Console.WriteLine();
        }

        public static void ChooseProduct(ref int id)
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
        }

        public static void ChooseManager(IRepository<Manager> manager)
        {
            Random rand = new Random();
            Console.WriteLine("Your manager will be {0}", manager.GetItem(rand.Next(1, 10)).name);
        }

        public static void RememberClient(IRepository<Client> client, int id, string name)
        {
            Client newClient = new Client(id, name);
            client.Save(newClient);
        }
    }
}
