using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.Entities;
using System.IO;

namespace Lab1.DataAccess
{
    public class ProjectRepository : IRepository<Project>
    {
        private ConstructionCompanyDataContext constructionCompanyDataContext = new ConstructionCompanyDataContext();

        public Project GetItem(int id)
        {
            return GetAll().FirstOrDefault(project => project.id == id);
        }

        public IEnumerable<Project> GetAll()
        {
            return constructionCompanyDataContext.Project.AsEnumerable<Project>();
        }

        public bool Add(Project item)
        {
            if (item != null)
            {
                constructionCompanyDataContext.Project.InsertOnSubmit(item);
                constructionCompanyDataContext.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            Project projectToDelete;
            try
            {
                projectToDelete = constructionCompanyDataContext.Project.Where(project => project.id == id).First();
            }
            catch
            {
                return false;
            }
            Delete(projectToDelete);
            return true;
        }

        public bool Delete(Project item)
        {
            if (item != null)
            {
                constructionCompanyDataContext.Project.DeleteOnSubmit(item);
                constructionCompanyDataContext.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}
