using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.Entities;
using System.IO;

namespace Lab1.DataAccess
{
    public class AgentRepository : IRepository<Agent>
    {
        private ConstructionCompanyDataContext constructionCompanyDataContext = new ConstructionCompanyDataContext();

        public Agent GetItem(int id)
        {
            return GetAll().FirstOrDefault(agent => agent.id == id);
        }

        public IEnumerable<Agent> GetAll()
        {
            return constructionCompanyDataContext.Agent.AsEnumerable<Agent>();
        }

        public bool Add(Agent item)
        {
            if (item != null)
            {
                constructionCompanyDataContext.Agent.InsertOnSubmit(item);
                constructionCompanyDataContext.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            Agent agentToDelete;
            try
            {
                agentToDelete = constructionCompanyDataContext.Agent.Where(agent => agent.id == id).First();
            }
            catch
            {
                return false;
            }
            Delete(agentToDelete);
            return true;
        }

        public bool Delete(Agent item)
        {
            if (item != null)
            {
                constructionCompanyDataContext.Agent.DeleteOnSubmit(item);
                constructionCompanyDataContext.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}
