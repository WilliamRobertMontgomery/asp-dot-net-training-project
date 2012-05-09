using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab2.Entities;
using Lab2.DataAccess;


namespace Lab2.BusinessLogic
{
    public class Realtor
    {


        /// <summary>
        /// Method check, if Product is Available
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static bool IsAvailable(Product product)
        {

            IRepository<Product> _productRepository = new ProductRepository();

            if (_productRepository.GetItem(product.id).status == "saled")
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        /// <summary>
        /// Method check, if Client is saved in file
        /// </summary>
        /// <param name="client"></param>
        /// <param name="name"></param>
        /// <returns></returns>

        public static bool IsExistingClient(IEnumerable<Client> client, string name)
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

        /// <summary>
        /// Method updates product status for "saled", because the Deal is done
        /// </summary>
        /// <param name="product"></param>
        /// <param name="id"></param>

        public static void Deal(IRepository<Product> product, int id)
        {
            Console.WriteLine("Consratulations! You have bought the product {0} on address {1}", product.GetItem(id).name, product.GetItem(id).address);
            Product saledProduct = new Product(id, product.GetItem(id).name, product.GetItem(id).address, "saled");
            product.Update(saledProduct);
        }

        /// <summary>
        /// Method checks, if user want to buy something else
        /// </summary>
        /// <returns></returns>

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

        /// <summary>
        /// Method prints Assortment of all the products
        /// </summary>
        /// <param name="productRepository"></param>


        public static void PrintAssortment(IEnumerable<Product> productRepository)
        {
            foreach (var item in productRepository)
            {
                Console.WriteLine("ID = {0}; Name = {1}; Address = {2}, Status = {3} ", item.id, item.name, item.address, item.status);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Method accepts number of product, which User chose
        /// </summary>
        /// <param name="id"></param>


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

        /// <summary>
        /// Method choses manager for user (at random. All the managers want to earn more money)
        /// </summary>
        /// <param name="manager"></param>


        public static void ChooseManager(IRepository<Manager> manager)
        {
            Random rand = new Random();
            Console.WriteLine("Your manager will be {0}", manager.GetItem(rand.Next(1, 10)).name);
        }


        /// <summary>
        /// Method saves a new Client in file
        /// </summary>
        /// <param name="client"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>

        public static void RememberClient(IRepository<Client> client, int id, string name)
        {
            Client newClient = new Client(id, name);
            client.Add(newClient);
        }
    }
}
