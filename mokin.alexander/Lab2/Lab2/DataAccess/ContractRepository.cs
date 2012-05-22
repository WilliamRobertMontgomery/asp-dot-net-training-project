using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.Entities;
using System.IO;

namespace Lab1.DataAccess
{
    public class ContractRepository : IRepository<Contract>
    {
        private ConstructionCompanyDataContext constructionCompanyDataContext = new ConstructionCompanyDataContext();

        public Contract GetItem(int id)
        {
            return GetAll().FirstOrDefault(contract => contract.id == id);
        }

        public IEnumerable<Contract> GetAll()
        {
            return constructionCompanyDataContext.Contract.AsEnumerable<Contract>();
        }

        public bool Add(Contract item)
        {
            if (item != null)
            {
                constructionCompanyDataContext.Contract.InsertOnSubmit(item);
                constructionCompanyDataContext.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            Contract contractToDelete;
            try
            {
                contractToDelete = constructionCompanyDataContext.Contract.Where(contract => contract.id == id).First();
            }
            catch
            {
                return false;
            }
            Delete(contractToDelete);
            return true;
        }

        public bool Delete(Contract item)
        {
            if (item != null)
            {
                constructionCompanyDataContext.Contract.DeleteOnSubmit(item);
                constructionCompanyDataContext.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}
