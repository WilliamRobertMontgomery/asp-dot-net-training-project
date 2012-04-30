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
        private const string filePath = "Projects.txt";

        public Project GetItem(int id)
        {
            return GetAll().FirstOrDefault(project => project.id == id);
        }

        public IEnumerable<Project> GetAll()
        {
            string[] projects = null;
            string[] projectFields;
            try
            {
                projects = File.ReadAllLines(filePath);
            }
            catch
            {
                return new Project[] { new Project(0, null, new DateTime(2012, 1, 1, 0, 0, 0)) }.Select(x => x);
            }
            return projects.Select(project =>
            {
                projectFields = project.Split(',');
                return new Project(Int32.Parse(projectFields[0]), projectFields[1], DateTime.Parse(projectFields[2]));
            });
        }

        public bool Add(Project item)
        {
            FileInfo fi = new FileInfo(filePath);
            StreamWriter streamWriter = fi.AppendText();
            streamWriter.WriteLine(item.id.ToString() + ',' + item.name + ',' + item.deadLine.ToString());
            streamWriter.Close();
            return true;
        }

        public bool Delete(int id)
        {
            var projects = GetAll().Where(project => project.id != id);
            StreamWriter streamWriter = new StreamWriter(filePath);
            foreach (var project in projects)
            {
                streamWriter.WriteLine(project.id.ToString() + ',' + project.name + ',' + project.deadLine.ToString());
            }
            streamWriter.Close();
            return true;
        }

        public bool Delete(Project item)
        {
            var projects = GetAll().Where(project => !project.Equals(item));
            StreamWriter streamWriter = new StreamWriter(filePath);
            foreach (var project in projects)
            {
                streamWriter.WriteLine(project.id.ToString() + ',' + project.name + ',' + project.deadLine.ToString());
            }
            streamWriter.Close();
            return true;
        }
    }
}
