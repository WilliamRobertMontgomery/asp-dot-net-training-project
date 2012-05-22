using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.Entities;
using System.IO;

namespace Lab1.DataAccess
{
    public class BuilderRepository : IRepository<Builder>
    {
        private ConstructionCompanyDataContext constructionCompanyDataContext = new ConstructionCompanyDataContext();

        public Builder GetItem(int id)
        {
            return GetAll().FirstOrDefault(builder => builder.id == id);
        }

        public IEnumerable<Builder> GetAll()
        {
            return constructionCompanyDataContext.Builder.AsEnumerable<Builder>();
        }

        public bool Add(Builder item)
        {
            if (item != null)
            {
                constructionCompanyDataContext.Builder.InsertOnSubmit(item);
                constructionCompanyDataContext.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            Builder builderToDelete;
            try
            {
                builderToDelete = constructionCompanyDataContext.Builder.Where(builder => builder.id == id).First();
            }
            catch
            {
                return false;
            }
            Delete(builderToDelete);
            return true;
        }

        public bool Delete(Builder item)
        {
            if (item != null)
            {
                constructionCompanyDataContext.Builder.DeleteOnSubmit(item);
                constructionCompanyDataContext.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}
