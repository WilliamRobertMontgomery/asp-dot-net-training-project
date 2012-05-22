using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Lab1.DataAccess;
using Lab1.Entities;

namespace repositoryTest
{
    [TestFixture]
    public class RepositoryTest
    {
        [Test]
        public void AgentRepositoryTest()
        {
            AgentRepository repository = new AgentRepository();
            Agent expectedAgent = new Agent(repository.GetAll().Count() + 1, "agensomeagent");
            
            repository.Add(expectedAgent);

           
            Agent realAgent = repository.GetItem(expectedAgent.id);
            
            Assert.AreEqual(expectedAgent, realAgent);

            repository.Delete(expectedAgent);
            

            realAgent = repository.GetItem(expectedAgent.id);

            Assert.AreEqual(null, realAgent);

        }

        [Test]
        public void BuilderRepositoryRepositoryTest()
        {
            BuilderRepository repository = new BuilderRepository();
            Builder expectedBuilder = new Builder(repository.GetAll().Count()+1, "BuildersomeBuilder");

            repository.Add(expectedBuilder);


            Builder realBuilder = repository.GetItem(expectedBuilder.id);

            Assert.AreEqual(expectedBuilder, realBuilder);

            repository.Delete(expectedBuilder);


            realBuilder = repository.GetItem(expectedBuilder.id);

            Assert.AreEqual(null, realBuilder);

        }

        [Test]
        public void ClientRepositoryTest()
        {
            ClientRepository repository = new ClientRepository();
            Client expectedClient = new Client(repository.GetAll().Count() + 1, "clientsomeclient");

            repository.Add(expectedClient);


            Client realClient = repository.GetItem(expectedClient.id);

            Assert.AreEqual(expectedClient, realClient);

            repository.Delete(expectedClient);


            realClient = repository.GetItem(expectedClient.id);

            Assert.AreEqual(null, realClient);

        }

        [Test]
        public void ProjectRepositoryTest()
        {
            ProjectRepository repository = new ProjectRepository();
            DateTime time = DateTime.MinValue;
            Project expectedProject = new Project(repository.GetAll().Count() + 1, "projectsomeproject", time);

            repository.Add(expectedProject);


            Project realProject = repository.GetItem(expectedProject.id);

            Assert.AreEqual(expectedProject, realProject);

            repository.Delete(expectedProject);


            realProject = repository.GetItem(expectedProject.id);

            Assert.AreEqual(null, realProject);

        }        

    }
}
