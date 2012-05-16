using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab4;


namespace Lab4.Models.DataAccess
{
    public class ProductRepository:IRepository<Product>
    {
        private QuiescencyEntitiesDataContext productDataContext;

        public ProductRepository()
        {
            productDataContext = new QuiescencyEntitiesDataContext();
        }

        public Product GetItem(int id)
        {
            return productDataContext.Product.SingleOrDefault(t => t.id == id);
        }

        public IEnumerable<Product> GetItems()
        {
            return productDataContext.Product.AsEnumerable<Product>();
        }

        public void Add(Product item)
        {
            productDataContext.Product.InsertOnSubmit(item);
            productDataContext.SubmitChanges();
            
        }


        

        public void Remove(Product item)
        {

            productDataContext.Product.DeleteOnSubmit(item);
            productDataContext.SubmitChanges();
           
        }

        public void Remove(int id)
        {

            Product temp = productDataContext.Product.SingleOrDefault(t => t.id == id);
            if (temp != null)
            {
                productDataContext.Product.DeleteOnSubmit(temp);
                productDataContext.SubmitChanges();
            }
        }

        public void Update(Product item)
        {
            Product itemUpdate = GetItem(item.id);
            if (itemUpdate != null)
            {
                itemUpdate.name = item.name;
                itemUpdate.address = item.address;
                itemUpdate.status = item.status;

                productDataContext.SubmitChanges();
            }
        }
    }
}
