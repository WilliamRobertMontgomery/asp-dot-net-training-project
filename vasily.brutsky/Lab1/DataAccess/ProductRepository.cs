using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.Entities;
using Lab1.BusinessLogic;
using System.IO;

namespace Lab1.DataAccess
{
    public class ProductRepository:IRepository<Product>
    {
        private const string Products = "c:\\Products.txt";

        public Product GetItem(int id)
        {
           
            return GetItems()
                .FirstOrDefault(i => i.id == id);
        }

        public IEnumerable<Product> GetItems()
        {
            
            string[] products = File.ReadAllLines(Products);
            return
                products.Select(c =>
                {
                    string[] product = c.Split('|');
                    return new Product(System.Int32.Parse(product[0]), product[1], product[2],product[3]);
                });

        }

        public void Save(Product item)
        {

            var itemString = string.Join("|", item.id, item.name, item.address,item.status) + "\n";
            File.AppendAllText(Products, itemString);
            
        }

        public void Remove(Product item)
        {
            string[] products = File.ReadAllLines(Products);


            IEnumerable<Product> SelectedProducts = products.Select(c =>
            {
                string[] product = c.Split('|');

                return new Product(System.Int32.Parse(product[0]), product[1], product[2],product[3]);
            });



            StreamWriter a = new StreamWriter(Products, false);
            foreach (var i in SelectedProducts)
            {
                if (i.name != item.name && i.id != item.id && i.status==item.status && i.address==item.address)
                {
                    var itemString = string.Join("|", i.id, i.name, i.address, i.status) + "\n";
                    a.Write(itemString);
                }

            }


            a.Close();

        }

        public void Remove(int id)
        {
            string[] products = File.ReadAllLines(Products);


            IEnumerable<Product> SelectedProducts = products.Select(c =>
            {
                string[] product = c.Split('|');

                return new Product(System.Int32.Parse(product[0]), product[1], product[2], product[3]);
            });



            StreamWriter a = new StreamWriter(Products, false);
            foreach (var i in SelectedProducts)
            {
                if (   i.id != id )
                {
                    var itemString = string.Join("|", i.id, i.name, i.address, i.status) + "\n";
                    a.Write(itemString);
                }

            }


            a.Close();
        }

        public void Update(Product item)
        {
            IRepository<Product> _productRepository = new ProductRepository();
            IEnumerable<Product> productRepository = _productRepository.GetItems();

            Product[] product = productRepository.ToArray();

            product[item.id - 1] = item;

            StreamWriter clientRefresh = new StreamWriter(Products);
            clientRefresh.Flush();
            clientRefresh.Close();

            foreach (var i in product)
            {
                _productRepository.Save(i);
            }
        }
    }
}
