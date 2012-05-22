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
                        if (contract.builderId == builder.id)
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
            ProjectRepository projectRepository = new ProjectRepository();
            
            Project project = new Project();
            project.name = projectName;
            project.deadLine = DateTime.Now.Add(TimeSpan.Parse(periodOfExecution));

            projectRepository.Add(project);

            return projectRepository.GetAll().Last().id;

        }
    }
}
