using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.DataAccess;
using Lab1.Entities;

namespace Lab1.Business
{
    public static class BuilderLogic
    {
        private const string projectName = "Project";
        private const string periodOfExecution = "0.0:0:30";

        private const int maxNumberOfProjects = 4;

        public static int AskBuilders()
        {
            var builders = new BuilderRepository().GetAll();
            var contracts = new ContractRepository().GetAll();
            int numberOfProjects = 0;

            foreach (var builder in builders)
            {
                numberOfProjects = 0;
                
                foreach (var contract in contracts)
                {
                    try
                    {
                        if (contract.builder.id == builder.id)
                        {
                            numberOfProjects = numberOfProjects + 1;
                        }
                    }
                    catch
                    {
                        return builder.id;
                    }
                }

                if (numberOfProjects < maxNumberOfProjects)
                {
                    return builder.id;
                }
            }
            return -1;
        }

        public static int AskForTheProject()
        {
            var projects = new ProjectRepository().GetAll();
            int newProjectId;
            string newProjectName;
            foreach (var project in projects)
            {
                if (project.id == 0)
                {
                    newProjectId = 1;
                    newProjectName = projectName + newProjectId.ToString();
                    DateTime projectDeadLine = DateTime.Now;
                    new ProjectRepository().Add(new Project(newProjectId, projectName, DateTime.Now.Add(TimeSpan.Parse(periodOfExecution))));
                    return 1;
                }
            }
            try
            {
                newProjectId = projects.Last().id + 1;
            }
            catch
            {
                newProjectId = 1;
                newProjectName = projectName + newProjectId.ToString();
                DateTime projectDeadLine = DateTime.Now;
                new ProjectRepository().Add(new Project(newProjectId, projectName, DateTime.Now.Add(TimeSpan.Parse(periodOfExecution))));
                return 1;
            }
            new ProjectRepository().Add(new Project(newProjectId, projectName, DateTime.Now.Add(TimeSpan.Parse(periodOfExecution))));
            return newProjectId;

        }
    }
}
